
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/Barcode, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Barcode : ImageObject
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
        public override string Type => "Barcode";

        
        /// <summary>
        /// The barcode number
        /// </summary>
        /// <example>
        /// <code>
        /// "text": "0123456789"
        /// </code>
        /// </example>
        [DataMember(Name = "text", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Text { get; set; }


        /// <summary>
        /// A fallback rendered barcode image url in addition to the raw barcode details.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://fallback.image.example.com/476ac24c694da79c5e33731ebbb5f1"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public override Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Type of barcode, e.g. 'Code39'
        /// 
        /// If you are using this property, please join the discussion at proposal [#130](https://github.com/openactive/open-booking-api/issues/130).
        /// </summary>
        [DataMember(Name = "beta:codeType", EmitDefaultValue = false, Order = 1009)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string CodeType { get; set; }

    }
}
