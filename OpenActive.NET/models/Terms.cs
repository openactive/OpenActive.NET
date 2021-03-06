using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/DigitalDocument, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Terms : Schema.NET.DigitalDocument
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
        public override string Type => "Terms";

        /// <summary>
        /// The name of the terms. The name must distinguish this from other terms fields provided, e.g. 'Terms and Conditions' or 'Privacy Policy'.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// The date and time at which the webpage containing the contents of the terms, located at the `url`, was last updated.
        /// </summary>
        /// <example>
        /// <code>
        /// "dateModified": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "dateModified", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601DateTimeValuesConverter))]
        public new virtual DateTimeOffset? DateModified { get; set; }

        [DataMember(Name = "requiresExplicitConsent", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? RequiresExplicitConsent { get; set; }

        /// <summary>
        /// The URL of the webpage containing the contents of the terms.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }
    }
}
