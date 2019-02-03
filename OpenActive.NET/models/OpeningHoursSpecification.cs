
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [OpeningHoursSpecification](https://schema.org/OpeningHoursSpecification), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class OpeningHoursSpecification : Schema.NET.OpeningHoursSpecification
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "OpeningHoursSpecification";

        
        /// <summary>
        /// The closing time.
        /// </summary>
        /// <example>
        /// <code>
        /// "closes": "17:00"
        /// </code>
        /// </example>
        [DataMember(Name = "closes", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public new virtual TimeSpan? Closes { get; set; }


        /// <summary>
        /// Defines the day of the week upon which the Place is open
        /// </summary>
        /// <example>
        /// <code>
        /// "dayOfWeek": "https://schema.org/Monday"
        /// </code>
        /// </example>
        [DataMember(Name = "dayOfWeek", Order = 115)]
        public new virtual Schema.NET.DayOfWeek? DayOfWeek { get; set; }


        /// <summary>
        /// The opening time.
        /// </summary>
        /// <example>
        /// <code>
        /// "opens": "09:00"
        /// </code>
        /// </example>
        [DataMember(Name = "opens", Order = 115)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public new virtual TimeSpan? Opens { get; set; }

    }
}
