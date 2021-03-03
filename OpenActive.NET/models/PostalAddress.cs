
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/PostalAddress, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class PostalAddress : Schema.NET.PostalAddress
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
        public override string Type => "PostalAddress";


        /// <summary>
        /// The country, expressed as a two-letter ISO 3166-1 alpha-2 country code.
        /// </summary>
        /// <example>
        /// <code>
        /// "addressCountry": "GB"
        /// </code>
        /// </example>
        [DataMember(Name = "addressCountry", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string AddressCountry { get; set; }


        /// <summary>
        /// The locality, a suburb within a city or a town within a county or district.
        /// </summary>
        /// <example>
        /// <code>
        /// "addressLocality": "Shoreditch"
        /// </code>
        /// </example>
        [DataMember(Name = "addressLocality", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string AddressLocality { get; set; }


        /// <summary>
        /// The region, either a city or a county or district.
        /// </summary>
        /// <example>
        /// <code>
        /// "addressRegion": "London"
        /// </code>
        /// </example>
        [DataMember(Name = "addressRegion", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string AddressRegion { get; set; }


        /// <summary>
        /// The postal code.
        /// </summary>
        /// <example>
        /// <code>
        /// "postalCode": "EC2A 4JE"
        /// </code>
        /// </example>
        [DataMember(Name = "postalCode", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string PostalCode { get; set; }


        /// <summary>
        /// The street address.
        /// </summary>
        /// <example>
        /// <code>
        /// "streetAddress": "Open Data Institute, Floor 3, 65 Clifton St"
        /// </code>
        /// </example>
        [DataMember(Name = "streetAddress", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string StreetAddress { get; set; }

    }
}
