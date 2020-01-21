using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Globalization;

namespace OpenActive.NET.Rpde.Version1
{
    /// <summary>
    /// Strongly typed RpdeItem
    /// </summary>
    /// <typeparam name="T">Type of the data contained within the RpdeItem</typeparam>
    [DataContract]
    public class RpdeItem<T> : RpdeItem where T : Schema.NET.Thing
    {
        [DataMember(Name = "data", EmitDefaultValue = false, Order = 5)]
        [JsonConverter(typeof(OpenActiveThingConverter))]
        public new T Data
        {
            get {
                return (T)base.Data;
            }
            set {
                base.Data = value;
            }
        }
    }

    [DataContract]
    public class RpdeItem
    {
        [DataMember(Name = "state", EmitDefaultValue = false, Order = 1)]
        public RpdeState? State { get; set; }
        [DataMember(Name = "kind", EmitDefaultValue = false, Order = 2)]
        public RpdeKind? Kind { get; set; }
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 3)]
        [JsonConverter(typeof(ValuesConverter))]
        public ComparableSingleValue<long, string>? Id { get; set; }
        [DataMember(Name = "modified", EmitDefaultValue = false, Order = 4)]
        public long? Modified { get; set; }
        [DataMember(Name = "data", EmitDefaultValue = false, Order = 5)]
        [JsonConverter(typeof(OpenActiveThingConverter))]
        public virtual Schema.NET.Thing Data { get; set; }
    }

    [DataContract]
    public class RpdePage
    {
        [DataMember(Name = "next", EmitDefaultValue = false, Order = 1)]
        public string Next { get; set; }
        [DataMember(Name = "items", EmitDefaultValue = false, Order = 2)]
        public List<RpdeItem> Items { get; set; }
        [DataMember(Name = "license", EmitDefaultValue = false, Order = 3)]
        public string License { get; set; } = "https://creativecommons.org/licenses/by/4.0/";


        /// <summary>
        /// Default serializer settings used.
        /// </summary>
        internal static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Returns the serialised representation of an RpdePage.
        /// Note that OpenActiveSerializer.Serialize<T> cannot be used on an RpdePage, as RPDE itself is not an JSON-LD based format.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public override string ToString() => OpenActiveSerializer.SerializeRpdePage(this);

        /// <summary>
        /// This is provided as a convenience to .NET Framework users, to create a standards compliant JSON output.
        /// .NET Core users are advised to use the Open Booking SDK, which targets a newer version of .NET and includes
        /// similar features that are compatible with .NET Core
        /// </summary>
        /// <example>
        /// var resp = req.CreateResponse(HttpStatusCode.OK);
        /// resp.Content = rpdePage.ToStringContent();
        /// </example>
        /// <returns></returns>
        public StringContent ToStringContent()
        {
            var content = new StringContent(this.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(OpenActiveMediaTypes.RealtimePagedDataExchange.Version1);
            return content;
        }

        // Constructor for JSON deserialisation
        public RpdePage() {}

        /// <summary>
        /// Creates a new RPDE Page based on the RPDE Items provided, using the Modified Timestamp and ID Ordering Strategy.
        /// Also validates that the items are in the correct order, throwing a SerializationException if this is not the case.
        /// </summary>
        /// <param name="feedBaseUrl">The base URL of the feed, used to construct the "next" URL.</param>
        /// <param name="afterTimestamp">The afterTimestamp query parameter value of the current request.</param>
        /// <param name="afterId">The afterId query parameter value of the current request.</param>
        /// <param name="items">Items to include in the RPDE Page</param>
        public RpdePage(Uri feedBaseUrl, long? afterTimestamp, ComparableSingleValue<long, string>? afterId, List<RpdeItem> items)
        {
            this.Items = items;
            SetNextModifiedID(feedBaseUrl, afterTimestamp, afterId);
        }


        /// <summary>
        /// Creates a new RPDE Page based on the RPDE Items provided, using the Incrementing Unique Change Number Ordering Strategy.
        /// Also validates that the items are in the correct order, throwing a SerializationException if this is not the case.
        /// </summary>
        /// <param name="feedBaseUrl">The base URL of the feed, used to construct the "next" URL</param>
        /// <param name="afterChangeNumber">The afterChangeNumber query parameter value of the current request</param>
        /// <param name="items">Items to include in the RPDE Page</param>
        public RpdePage(Uri feedBaseUrl, long? afterChangeNumber, List<RpdeItem> items)
        {
            this.Items = items;
            SetNextChangeNumber(feedBaseUrl, afterChangeNumber);
        }


        /// <summary>
        /// Use the Modified Timestamp and ID Ordering Strategy to set the "next" URL based on the current Items
        /// of the instance and provided afterTimestamp and afterId.
        /// Also validates that the items are in the correct order, throwing a SerializationException if this is not the case.
        /// </summary>
        /// <param name="feedBaseUrl">The base URL of the feed, used to construct the "next" URL.</param>
        /// <param name="afterTimestamp">The afterTimestamp query parameter value of the current request.</param>
        /// <param name="afterId">The afterId query parameter value of the current request.</param>
        public void SetNextModifiedID(Uri feedBaseUrl, long? afterTimestamp, ComparableSingleValue<long, string>? afterId)
        {
            // If there is at least one item, run validation on items array
            var firstItem = Items.FirstOrDefault();
            if (firstItem != null)
            {
                // Checks that the afterId and afterTimestamp provided are not the
                // first item in the feed (helps detect whether query is correct)
                if (firstItem.Modified == afterTimestamp && firstItem.Id == afterId)
                {
                    throw new SerializationException("First item in the feed must never have same 'modified' and 'id' as afterTimestamp and afterId query parameters. Please check the RPDE specification and ensure you are using the correct query for your ordering strategy.");
                }

                // Check that items are ordered, and deleted items contain no data
                long? currentModified = -1;
                ComparableSingleValue<long, string>? currentId = firstItem.Id;
                foreach (var item in Items)
                {
                    if (item.State == RpdeState.Deleted && item.Data != null)
                    {
                        throw new SerializationException("Deleted items must not contain data.");
                    }

                    if (!item.State.HasValue || !item.Kind.HasValue || !item.Modified.HasValue || !item.Id.HasValue)
                    {
                        throw new SerializationException("All RPDE feed items must include id, modified, state and kind.");
                    }

                    if (item.Modified > currentModified || (item.Modified == currentModified && item.Id > currentId))
                    {
                        currentModified = item.Modified;
                        currentId = item.Id;
                    } else
                    {
                        throw new SerializationException($"Items must be ordered first by 'modified', then by 'id'. Item with id '{item.Id}' has modified '{item.Modified}' compared with previous item's modified '{currentModified}' and id '{currentId}'. Please check the RPDE specification and ensure you are using the correct query for your ordering strategy.");
                    }
                }
            }

            // Create 'next' URL depending on whether there are items available
            var lastItem = Items.LastOrDefault();
            if (lastItem != null)
            {
                Next = $"{feedBaseUrl}?afterTimestamp={lastItem.Modified}&afterId={lastItem.Id}";
            } else if (afterTimestamp.HasValue && afterId.HasValue)
            {
                // Last page, use existing values
                Next = $"{feedBaseUrl}?afterTimestamp={afterTimestamp}&afterId={afterId}";
            } else
            {
                // No items, use feed base URL
                Next = $"{feedBaseUrl}";
            }
        }

        /// <summary>
        /// Use the Incrementing Unique Change Number Ordering Strategy to set the "next" URL based on the current Items
        /// of the instance and provided afterChangeNumber.
        /// Also validates that the items are in the correct order, throwing a SerializationException if this is not the case.
        /// </summary>
        /// <param name="feedBaseUrl">The base URL of the feed, used to construct the "next" URL.</param>
        /// <param name="afterChangeNumber">The afterChangeNumber query parameter value of the current request</param>
        public void SetNextChangeNumber(Uri feedBaseUrl, long? afterChangeNumber)
        {
            // If there is at least one item, run validation on items array
            var firstItem = Items.FirstOrDefault();
            if (firstItem != null)
            {
                // Checks that the afterChangeNumber provided are not the
                // first item in the feed (helps detect whether query is correct)
                if (firstItem.Modified == afterChangeNumber)
                {
                    throw new SerializationException("First item in the feed must never have same 'modified' as afterChangeNumber query parameter. Please check the RPDE specification and ensure you are using the correct query for your ordering strategy.");
                }

                // Check that items are ordered
                long? currentChangeNumber = -1;
                foreach (var item in Items)
                {
                    if (item.State == RpdeState.Deleted && item.Data != null)
                    {
                        throw new SerializationException("Deleted items must not contain data.");
                    }

                    if (!item.State.HasValue || !item.Kind.HasValue || !item.Modified.HasValue || item.Id == null)
                    {
                        throw new SerializationException("All RPDE feed items must include id, modified, state and kind.");
                    }

                    if (item.Modified > currentChangeNumber)
                    {
                        currentChangeNumber = item.Modified;
                    }
                    else
                    {
                        throw new SerializationException($"Items must be ordered by 'modified'. Item with id '{item.Id}' has modified '{item.Modified}' compared with previous item's modified '{currentChangeNumber}'. Please check the RPDE specification and ensure you are using the correct query for your ordering strategy.");
                    }
                }
            }

            // Create 'next' URL depending on whether there are items available
            var lastItem = Items.LastOrDefault();
            if (lastItem != null)
            {
                Next = $"{feedBaseUrl}?afterChangeNumber={lastItem.Modified}";
            }
            else if (afterChangeNumber.HasValue)
            {
                // Last page, use existing values
                Next = $"{feedBaseUrl}?afterChangeNumber={afterChangeNumber}";
            } else
            {
                // No items, use feed base URL
                Next = $"{feedBaseUrl}";
            }
        }
    }

    public enum RpdeState
    {
        [EnumMember(Value = "updated")]
        Updated,
        [EnumMember(Value = "deleted")]
        Deleted
    }

    public enum RpdeKind
    {
        [EnumMember(Value = "SessionSeries")]
        SessionSeries,
        [EnumMember(Value = "ScheduledSession")]
        ScheduledSession,
        [EnumMember(Value = "ScheduledSession.SessionSeries")]
        ScheduledSessionSessionSeries,
        [EnumMember(Value = "SessionSeries.ScheduledSession")]
        SessionSeriesScheduledSession,
        [EnumMember(Value = "FacilityUse")]
        FacilityUse,
        [EnumMember(Value = "IndividualFacilityUse")]
        IndividualFacilityUse,
        [EnumMember(Value = "Slot")]
        Slot,
        [EnumMember(Value = "FacilityUse/Slot")]
        FacilityUseSlot,
        [EnumMember(Value = "IndividualFacilityUse/Slot")]
        IndividualFacilityUseSlot,
        [EnumMember(Value = "Course")]
        Course,
        [EnumMember(Value = "CourseInstance")]
        CourseInstance,
        [EnumMember(Value = "HeadlineEvent")]
        HeadlineEvent,
        [EnumMember(Value = "Event")]
        Event,
        [EnumMember(Value = "EventSeries")]
        EventSeries,
        [EnumMember(Value = "Order")]
        Order
    }


    /// <summary>
    /// Converts an <see cref="Schema.NET.Thing"/> object to JSON-LD, with the "@context" property at the root.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class OpenActiveThingConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType) => objectType == typeof(Schema.NET.Thing);

        /// <summary>
        /// Writes the object retrieved from <see cref="Schema.NET.Thing"/> when one is found.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else if (value is Schema.NET.Thing thing)
            {
                writer.WriteRawValue(OpenActiveSerializer.Serialize(thing));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string json = ReadOuterJson(reader);
            if (json == null)
            {
                return null;
            }
            else
            {
                var thing = OpenActiveSerializer.Deserialize<Schema.NET.Thing>(json);
                if (thing != null)
                {
                    return thing;
                }
                else
                {
                    // The resulting class cannot be assigned to Schema.NET.Thing
                    throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// See https://stackoverflow.com/questions/56944160/efficiently-get-full-json-string-in-jsonconverter-readjson
        /// </summary>
        private static string ReadOuterJson(JsonReader reader, Formatting formatting = Formatting.None, DateParseHandling? dateParseHandling = DateParseHandling.None, FloatParseHandling? floatParseHandling = null)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var oldDateParseHandling = reader.DateParseHandling;
            var oldFloatParseHandling = reader.FloatParseHandling;
            try
            {
                if (dateParseHandling != null)
                    reader.DateParseHandling = dateParseHandling.Value;
                if (floatParseHandling != null)
                    reader.FloatParseHandling = floatParseHandling.Value;
                using (var sw = new StringWriter(CultureInfo.InvariantCulture))
                using (var jsonWriter = new JsonTextWriter(sw) { Formatting = formatting })
                {
                    jsonWriter.WriteToken(reader);
                    return sw.ToString();
                }
            }
            finally
            {
                reader.DateParseHandling = oldDateParseHandling;
                reader.FloatParseHandling = oldFloatParseHandling;
            }
        }
    }


}
