
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/EntryPoint, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class EntryPoint : Schema.NET.EntryPoint
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
        public override string Type => "EntryPoint";

        
        /// Must always be present and set to <code>
        /// "encodingType": "application/vnd.openactive.v1.0+json"
        /// </code>
        [DataMember(Name = "encodingType", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string EncodingType { get; set; }


        /// <summary>
        /// An HTTP method that specifies the appropriate HTTP method for a request to an HTTP EntryPoint. Values are capitalized strings as used in HTTP.
        /// </summary>
        /// <example>
        /// <code>
        /// "httpMethod": "POST"
        /// </code>
        /// </example>
        [DataMember(Name = "httpMethod", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string HttpMethod { get; set; }


        /// <summary>
        /// URL of the item
        /// </summary>
        /// <example>
        /// <code>
        /// "urlTemplate": "https://example.com/orders{/var}"
        /// </code>
        /// </example>
        [DataMember(Name = "urlTemplate", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri UrlTemplate { get; set; }

    }
}
