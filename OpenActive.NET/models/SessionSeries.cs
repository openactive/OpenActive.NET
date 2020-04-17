
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
    public partial class SessionSeries : Event
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
        public override string Type => "SessionSeries";

        
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


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override long? RemainingAttendeeCapacity { get; set; }


        /// <summary>
        /// Relates a parent event to a child event. Properties describing the parent event can be assumed to apply to the child, unless otherwise specified. A child event might be a specific instance of an Event within a schedule
        /// </summary>
        [DataMember(Name = "subEvent", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<ScheduledSession> SubEvent { get; set; }

    }
}
