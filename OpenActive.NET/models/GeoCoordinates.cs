
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/GeoCoordinates, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class GeoCoordinates : Schema.NET.GeoCoordinates
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
        public override string Type => "GeoCoordinates";


        /// <summary>
        /// The latitude of a location. For example 51.522338 (WGS 84).
        /// </summary>
        /// <example>
        /// <code>
        /// "latitude": 51.522338
        /// </code>
        /// </example>
        [DataMember(Name = "latitude", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual decimal? Latitude { get; set; }


        /// <summary>
        /// The longitude of a location. For example -0.083437 (WGS 84).
        /// </summary>
        /// <example>
        /// <code>
        /// "longitude": -0.083437
        /// </code>
        /// </example>
        [DataMember(Name = "longitude", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual decimal? Longitude { get; set; }

    }
}
