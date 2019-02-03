
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Brand](https://schema.org/Brand), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Brand : Schema.NET.Brand
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Brand";

        
        /// <summary>
        /// A text description for the brand.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Play Ball! is a series of games for people of all abilities."
        /// </code>
        /// </example>
        [DataMember(Name = "description", Order = 115)]
        public new virtual string Description { get; set; }


        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "BR1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// The logo associated with the brand.
        /// </summary>
        /// <example>
        /// <code>
        /// "logo": {
        ///   "type": "ImageObject",
        ///   "url": "http://example.com/static/image/speedball_large.jpg"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "logo", Order = 115)]
        public new virtual ImageObject Logo { get; set; }


        /// <summary>
        /// The name of the brand.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Play Ball!"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A url where further information can be found for the brand.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://example.com/play_ball"
        /// </code>
        /// </example>
        [DataMember(Name = "url", Order = 115)]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// An related video object.
        /// 
        /// If you are using this property, please join the discussion at proposal [#88](https://github.com/openactive/modelling-opportunity-data/issues/88).
        /// </summary>
        [DataMember(Name = "beta:video", Order = 115)]
        public virtual List<Schema.NET.VideoObject> Video { get; set; }

    }
}
