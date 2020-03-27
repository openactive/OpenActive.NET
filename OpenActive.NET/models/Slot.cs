
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/Event, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Slot : Event
    {
        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// This method overrides Schema.NET ToString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents the JSON-LD representation of this instance.</returns>
        public override string ToString()
        {
            return OpenActiveSerializer.Serialize(this);
        }

        /// <summary>
        /// Returns the JSON-LD representation of this instance, including "https://schema.org" in the "@context".
        ///
        /// This method must be used when you want to embed the output raw (as-is) into a web
        /// page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
        /// vulnerabilities if the object was constructed from an untrusted source.
        /// 
        /// This method overrides Schema.NET ToHtmlEscapedString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public new string ToHtmlEscapedString()
        {
            return OpenActiveSerializer.SerializeToHtmlEmbeddableString(this);
        }

        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Slot";

        
        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public override SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string Name { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string Description { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string AccessibilityInformation { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Concept> AccessibilitySupport { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Concept> Activity { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override QuantitativeValue AgeRange { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string AttendeeInstructions { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override SingleValues<List<string>, List<Concept>> Category { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Person> Contributor { get; set; }


        /// <summary>
        /// The duration of the slot given in [ISO8601] format.
        /// </summary>
        /// <example>
        /// <code>
        /// "duration": "PT1H"
        /// </code>
        /// </example>
        [DataMember(Name = "duration", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public override TimeSpan? Duration { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override EventAttendanceModeEnumeration? EventAttendanceMode { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Schedule> EventSchedule { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Schema.NET.EventStatusType? EventStatus { get; set; }


        /// <summary>
        /// FacilityUse or IndividualFacilityUse that has this offer, either directly embedded or referenced by its @id
        /// </summary>
        /// <example>
        /// <code>
        /// "facilityUse": "https://example.com/facility-use/1"
        /// </code>
        /// </example>
        [DataMember(Name = "facilityUse", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual SingleValues<Uri, IndividualFacilityUse, FacilityUse> FacilityUse { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override GenderRestrictionType? GenderRestriction { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<ImageObject> Image { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override bool? IsAccessibleForFree { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override bool? IsCoached { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Person> Leader { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override SingleValues<List<string>, List<Concept>> Level { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Place Location { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? MaximumAttendeeCapacity { get; set; }


        /// <summary>
        /// The maximum available courts or pitches at this time. Must be 0 or 1 for an IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "maximumUses": 16
        /// </code>
        /// </example>
        [DataMember(Name = "maximumUses", EmitDefaultValue = false, Order = 30)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? MaximumUses { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? MaximumVirtualAttendeeCapacity { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string MeetingPoint { get; set; }


        /// <summary>
        /// An array of schema:Offer that include the price of booking.
        /// </summary>
        /// <example>
        /// <code>
        /// "offers": {
        ///   "@type": "Offer",
        ///   "identifier": "OX-AD",
        ///   "name": "Adult",
        ///   "price": 7.5,
        ///   "priceCurrency": "GBP",
        ///   "url": "https://profile.everyoneactive.com/booking?Site=0140&Activities=1402CBP20150217&Culture=en-GB"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "offers", EmitDefaultValue = false, Order = 33)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<Offer> Offers { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Brand Programme { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? RemainingAttendeeCapacity { get; set; }


        /// <summary>
        /// The remaining available courts or pitches at this time. Must be 0 or 1 for an IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "remainingUses": 5
        /// </code>
        /// </example>
        [DataMember(Name = "remainingUses", EmitDefaultValue = false, Order = 36)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? RemainingUses { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override string SchedulingNote { get; set; }


        /// <summary>
        /// The start date and time of the slot. Can be specified as a schema:Date or schema:DateTime
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", EmitDefaultValue = false, Order = 38)]
        [JsonConverter(typeof(ValuesConverter))]
        public override SingleValues<string, DateTimeOffset?> StartDate { get; set; }


        /// <summary>
        /// The end date and time of the slot. Can be specified as a schema:Date or schema:DateTime 
        /// It is recommended that publishers provide either an schema:endDate or a schema:duration for an slot.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", EmitDefaultValue = false, Order = 39)]
        [JsonConverter(typeof(ValuesConverter))]
        public override SingleValues<string, DateTimeOffset?> EndDate { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Event> SubEvent { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Event SuperEvent { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// Internal location of the event, e.g. Court 1
        /// 
        /// If you are using this property, please join the discussion at proposal [#110](https://github.com/openactive/modelling-opportunity-data/issues/110).
        /// </summary>
        [DataMember(Name = "beta:sportsActivityLocation", EmitDefaultValue = false, Order = 1043)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<SportsActivityLocation> SportsActivityLocation { get; set; }

    }
}
