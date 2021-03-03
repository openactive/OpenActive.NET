
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/OpeningHoursSpecification, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class OpeningHoursSpecification : Schema.NET.OpeningHoursSpecification
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
        public override string Type => "OpeningHoursSpecification";


        /// <summary>
        /// The closing time. Set "00:00" for the value of `opens` and `closes` to indicated the `Place` is closed on the specified days.
        /// </summary>
        /// <example>
        /// <code>
        /// "closes": "17:00"
        /// </code>
        /// </example>
        [DataMember(Name = "closes", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601TimeValuesConverter))]
        public new virtual DateTimeOffset? Closes { get; set; }


        /// <summary>
        /// Defines the days of the week upon which the `opens` and `closes` values are specified. Note this property is optional when used within `specialOpeningHoursSpecification`.
        /// </summary>
        /// <example>
        /// <code>
        /// "dayOfWeek": [
        ///   "https://schema.org/Saturday",
        ///   "https://schema.org/Sunday"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "dayOfWeek", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Schema.NET.DayOfWeek> DayOfWeek { get; set; }


        /// <summary>
        /// The opening time. Set "00:00" for the value of `opens` and `closes` to indicated the `Place` is closed on the specified days.
        /// </summary>
        /// <example>
        /// <code>
        /// "opens": "09:00"
        /// </code>
        /// </example>
        [DataMember(Name = "opens", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601TimeValuesConverter))]
        public new virtual DateTimeOffset? Opens { get; set; }


        /// <summary>
        /// The date when the item becomes valid. The item will be valid at the beginning of the specified day. Note this property is required when used within `specialOpeningHoursSpecification`.
        /// </summary>
        /// <example>
        /// <code>
        /// "validFrom": "2018-01-22"
        /// </code>
        /// </example>
        [DataMember(Name = "validFrom", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string ValidFrom { get; set; }


        /// <summary>
        /// The date after which the item is no longer valid. The item will cease to be valid at the end of the specified day. Note this property is required when used within `specialOpeningHoursSpecification`.
        /// </summary>
        /// <example>
        /// <code>
        /// "validThrough": "2018-01-27"
        /// </code>
        /// </example>
        [DataMember(Name = "validThrough", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string ValidThrough { get; set; }

    }
}
