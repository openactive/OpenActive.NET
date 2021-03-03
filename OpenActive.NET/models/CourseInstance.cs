using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/CourseInstance, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class CourseInstance : Event
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
        public override string Type => "CourseInstance";

        /// <summary>
        /// A an array of oa:Schedule or oa:PartialSchedule, which represents a recurrence pattern.
        /// </summary>
        /// <example>
        /// <code>
        /// "eventSchedule": [
        ///   {
        ///     "@type": "PartialSchedule",
        ///     "repeatFrequency": "P1W",
        ///     "startTime": "20:15",
        ///     "endTime": "20:45",
        ///     "byDay": [
        ///       "http://schema.org/Tuesday"
        ///     ],
        ///     "scheduleTimezone": "Europe/London"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "eventSchedule", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Schedule> EventSchedule { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// This course for which this is an offering.
        /// 
        /// If you are using this property, please join the discussion at proposal [#164](https://github.com/openactive/modelling-opportunity-data/issues/164).
        /// </summary>
        [DataMember(Name = "beta:course", EmitDefaultValue = false, Order = 1008)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Course Course { get; set; }
    }
}
