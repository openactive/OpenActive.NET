
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
    public class Slot : Schema.NET.Event
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Slot";

        
        /// <summary>
        /// The duration of the slot given in [ISO8601] format.
        /// </summary>
        /// <example>
        /// <code>
        /// "duration": "PT1H"
        /// </code>
        /// </example>
        [DataMember(Name = "duration", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public new virtual TimeSpan? Duration { get; set; }


        /// <summary>
        /// The end date and time of the slot. Can be specified as a schema:Date or schema:DateTime 
        /// It is recommended that publishers provide either an schema:endDate or a schema:duration for an slot.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<DateTimeOffset?, DateTimeOffset?> EndDate { get; set; }


        /// <summary>
        /// URI to the FacilityUse that has this offer
        /// </summary>
        /// <example>
        /// <code>
        /// "facilityUse": "https://example.com/facility-use/1"
        /// </code>
        /// </example>
        [DataMember(Name = "facilityUse", Order = 115)]
        public virtual Uri FacilityUse { get; set; }


        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// The maximum available courts or pitches at this time. Must be 0 or 1 for an IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "maximumUses": 16
        /// </code>
        /// </example>
        [DataMember(Name = "maximumUses", Order = 115)]
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
        [DataMember(Name = "offers", Order = 115)]
        public new virtual List<Offer> Offers { get; set; }


        /// <summary>
        /// The remaining available courts or pitches at this time. Must be 0 or 1 for an IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "remainingUses": 5
        /// </code>
        /// </example>
        [DataMember(Name = "remainingUses", Order = 115)]
        public virtual int? RemainingUses { get; set; }


        /// <summary>
        /// The start date and time of the slot. Can be specified as a schema:Date or schema:DateTime
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<DateTimeOffset?, DateTimeOffset?> StartDate { get; set; }

    }
}
