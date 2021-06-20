using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Event, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class ScheduledSession : Event
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
        public override string Type => "ScheduledSession";

        /// <summary>
        /// The start date and time of the event.
        /// </summary>
        /// <example>
        /// <code>
        /// "startDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "startDate", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public override DateTimeValue StartDate { get { return base.StartDate; } set { if (value.IsDateOnly) throw new ArgumentOutOfRangeException("This property must be set to a DateTimeOffset, including a time"); base.StartDate = value; } }

        /// <summary>
        /// The end date and time of the event.
        /// It is recommended that publishers provide either an schema:endDate or a schema:duration for an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "endDate": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "endDate", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public override DateTimeValue EndDate { get { return base.EndDate; } set { if (value.IsDateOnly) throw new ArgumentOutOfRangeException("This property must be set to a DateTimeOffset, including a time"); base.EndDate = value; } }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override List<Event> SubEvent { get; set; }

        /// <summary>
        /// Relates a child event to a parent event. Properties describing the parent event can be assumed to apply to the child, unless otherwise specified. A parent event might specify a recurring schedule, of which the child event is one specific instance
        /// </summary>
        [DataMember(Name = "superEvent", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ReferenceValue<Event> SuperEvent { get; set; }
    }
}
