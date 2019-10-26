
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Barcode](https://schema.org/Barcode), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class Barcode : ImageObject
    {
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
        public new virtual Uri Url { get; set; }

    }
}
