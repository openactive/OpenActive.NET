
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/MediaObject, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class MediaObject : Schema.NET.MediaObject
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
        public override string Type => "MediaObject";

        
        /// <summary>
        /// Actual bytes of the media object, for example the image file or video file.
        /// </summary>
        /// <example>
        /// <code>
        /// "contentUrl": "https://example.com/media/stayin/getfit"
        /// </code>
        /// </example>
        [DataMember(Name = "contentUrl", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri ContentUrl { get; set; }


        /// <summary>
        /// A URL pointing to a player for a specific video. In general, this is the information in the src element of an embed tag and should not be the same as the content of the loc tag.
        /// </summary>
        /// <example>
        /// <code>
        /// "embedUrl": "https://example.com/media/stayin/getfit"
        /// </code>
        /// </example>
        [DataMember(Name = "embedUrl", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri EmbedUrl { get; set; }


        /// <summary>
        /// The height of the media in pixels.
        /// </summary>
        /// <example>
        /// <code>
        /// "height": 300
        /// </code>
        /// </example>
        [DataMember(Name = "height", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual long? Height { get; set; }


        /// <summary>
        /// The URL for a thumbnail image for the media.
        /// </summary>
        [DataMember(Name = "thumbnail", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<ImageObject> Thumbnail { get; set; }


        /// <summary>
        /// The URL for the page containing the media.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://example.com/media/stayin/getfit"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// The width of the media in pixels.
        /// </summary>
        /// <example>
        /// <code>
        /// "width": 400
        /// </code>
        /// </example>
        [DataMember(Name = "width", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual long? Width { get; set; }

    }
}
