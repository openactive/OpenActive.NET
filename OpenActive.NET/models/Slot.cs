
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    [DataContract]
    public partial class Slot : Schema.NET.Event
    {
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
        public new virtual SingleValues<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// The duration of the slot given in [ISO8601] format.
        /// </summary>
        /// <example>
        /// <code>
        /// "duration": "PT1H"
        /// </code>
        /// </example>
        [DataMember(Name = "duration", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public new virtual TimeSpan? Duration { get; set; }


        /// <summary>
        /// URI to the FacilityUse that has this offer
        /// </summary>
        /// <example>
        /// <code>
        /// "facilityUse": "https://example.com/facility-use/1"
        /// </code>
        /// </example>
        [DataMember(Name = "facilityUse", EmitDefaultValue = false, Order = 9)]
        public virtual Uri FacilityUse { get; set; }


        /// <summary>
        /// The maximum available courts or pitches at this time. Must be 0 or 1 for an IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "maximumUses": 16
        /// </code>
        /// </example>
        [DataMember(Name = "maximumUses", EmitDefaultValue = false, Order = 10)]
        public virtual int? MaximumUses { get; set; }


        /// <summary>
        /// An array of schema:Offer that include the price of booking.
        /// </summary>
        /// <example>
        /// <code>
        /// "offers": {
        ///   "type": "Offer",
        ///   "identifier": "OX-AD",
        ///   "name": "Adult",
        ///   "price": 7.5,
        ///   "priceCurrency": "GBP",
        ///   "url": "https://profile.everyoneactive.com/booking?Site=0140&Activities=1402CBP20150217&Culture=en-GB"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "offers", EmitDefaultValue = false, Order = 11)]
        public new virtual List<Offer> Offers { get; set; }


        /// <summary>
        /// The remaining available courts or pitches at this time. Must be 0 or 1 for an IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "remainingUses": 5
        /// </code>
        /// </example>
        [DataMember(Name = "remainingUses", EmitDefaultValue = false, Order = 12)]
        public virtual int? RemainingUses { get; set; }


        /// <summary>
        /// The start date and time of the slot. Can be specified as a schema:Date or schema:DateTime
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, DateTimeOffset?> StartDate { get; set; }


        /// <summary>
        /// The end date and time of the slot. Can be specified as a schema:Date or schema:DateTime 
        /// It is recommended that publishers provide either an schema:endDate or a schema:duration for an slot.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, DateTimeOffset?> EndDate { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// Internal location of the event, e.g. Court 1
        /// 
        /// If you are using this property, please join the discussion at proposal [#110](https://github.com/openactive/modelling-opportunity-data/issues/110).
        /// </summary>
        [DataMember(Name = "beta:sportsActivityLocation", EmitDefaultValue = false, Order = 1015)]
        public virtual List<SportsActivityLocation> SportsActivityLocation { get; set; }

    }
}
