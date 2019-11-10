
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [EntryPoint](https://schema.org/EntryPoint), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class EntryPoint : Schema.NET.EntryPoint
    {
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
