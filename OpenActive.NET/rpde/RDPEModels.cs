using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http;

namespace OpenActive.NET.Rpde.Version1
{
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
        public Schema.NET.Thing Data { get; set; }
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
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public override string ToString() => this.ToString(SerializerSettings);

        /// <summary>
        /// Returns the JSON-LD representation of this instance using the <see cref="JsonSerializerSettings"/> provided.
        /// </summary>
        /// <param name="serializerSettings">Serialization settings.</param>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public string ToString(JsonSerializerSettings serializerSettings) =>
            JsonConvert.SerializeObject(this, serializerSettings);
        
        public StringContent ToStringContent()
        {
            var content = new StringContent(this.ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = OpenActiveDiscovery.MediaTypes.Version1.RealtimePagedDataExchange;
            return content;
        }

        // Constructor for JSON deserialisation
        public RpdePage() {}

        public RpdePage(string feedBaseUrl, long? modified, ComparableSingleValue<long, string>? id, List<RpdeItem> items)
        {
            this.Items = items;
            SetNextModifiedID(feedBaseUrl, modified, id);
        }

        public RpdePage(string feedBaseUrl, long? changeNumber, List<RpdeItem> items)
        {
            this.Items = items;
            SetNextChangeNumber(feedBaseUrl, changeNumber);
        }

        public void SetNextModifiedID(string feedBaseUrl, long? modified, ComparableSingleValue<long, string>? id)
        {
            // If there is at least one item, run validation on items array
            var firstItem = Items.FirstOrDefault();
            if (firstItem != null)
            {
                // Checks that the afterId and afterTimestamp provided are not the
                // first item in the feed (helps detect whether query is correct)
                if (firstItem.Modified == modified && firstItem.Id == id)
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

                    if (!item.State.HasValue || !item.Kind.HasValue || !item.Modified.HasValue || item.Id == null)
                    {
                        throw new SerializationException("All RPDE feed items must include id, modified, state and kind.");
                    }

                    if (item.Modified > currentModified || (item.Modified == currentModified && item.Id > currentId))
                    {
                        currentModified = item.Modified;
                        currentId = item.Id;
                    } else
                    {
                        throw new SerializationException("Items must be ordered first by 'modified', then by 'id'. Please check the RPDE specification and ensure you are using the correct query for your ordering strategy.");
                    }
                }
            }

            // Create 'next' URL depending on whether there are items available
            var lastItem = Items.LastOrDefault();
            if (lastItem != null)
            {
                Next = $"{feedBaseUrl}?afterTimestamp={lastItem.Modified}&afterId={lastItem.Id}";
            } else if (modified.HasValue && id != null)
            {
                // Last page, use existing values
                Next = $"{feedBaseUrl}?afterTimestamp={modified}&afterId={id}";
            } else
            {
                // No items, use feed base URL
                Next = $"{feedBaseUrl}";
            }
        }

        public void SetNextChangeNumber(string feedBaseUrl, long? changeNumber)
        {
            // If there is at least one item, run validation on items array
            var firstItem = Items.FirstOrDefault();
            if (firstItem != null)
            {
                // Checks that the afterChangeNumber provided are not the
                // first item in the feed (helps detect whether query is correct)
                if (firstItem.Modified == changeNumber)
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
                        throw new SerializationException("Items must be ordered by 'modified'. Please check the RPDE specification and ensure you are using the correct query for your ordering strategy.");
                    }
                }
            }

            // Create 'next' URL depending on whether there are items available
            var lastItem = Items.LastOrDefault();
            if (lastItem != null)
            {
                Next = $"{feedBaseUrl}?afterChangeNumber={lastItem.Modified}";
            }
            else if (changeNumber.HasValue)
            {
                // Last page, use existing values
                Next = $"{feedBaseUrl}?afterChangeNumber={changeNumber}";
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
        EventSeries
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
                writer.WriteRawValue(thing.ToOpenActiveString());
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
