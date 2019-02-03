
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [ImageObject](https://schema.org/ImageObject), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class ImageObject : Schema.NET.ImageObject
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "ImageObject";

        
        /// <summary>
        /// The URL for a thumbnail image for an image.
        /// </summary>
        [DataMember(Name = "thumbnail", Order = 115)]
        public new virtual List<ImageObject> Thumbnail { get; set; }


        /// <summary>
        /// The URL for the display resolution image.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://example.com/static/image/speedball_large.jpg"
        /// </code>
        /// </example>
        [DataMember(Name = "url", Order = 115)]
        public new virtual Uri Url { get; set; }

    }
}
