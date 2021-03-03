using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/ImageObject, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class ImageObject : MediaObject
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
        public override string Type => "ImageObject";

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Uri ContentUrl { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Uri EmbedUrl { get; set; }

        /// <summary>
        /// The URL for a thumbnail image for an image.
        /// </summary>
        [DataMember(Name = "thumbnail", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<ImageObject> Thumbnail { get; set; }

        /// <summary>
        /// The URL for the display resolution image.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://example.com/static/image/speedball_large.jpg"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public override Uri Url { get; set; }
    }
}
