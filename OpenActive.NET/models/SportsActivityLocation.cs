using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/SportsActivityLocation, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class SportsActivityLocation : Place
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
        public override string Type => "SportsActivityLocation";

        /// <summary>
        /// The name of the SportsActivityLocation
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Basketball Hall"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public override string Name { get; set; }

        /// <summary>
        /// A plain text description of the SportsActivityLocation, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "The National Basketball Performance Centre (NBPC) is part of Belle Vue Sports Village.
        /// 
        /// - It features a purpose-built hall with 3 courts developed to FIBA standards for international competition and a multi-sports hall with a further 2 basketball courts.
        /// - The NBPC show court, which has basketball lines only, also features FIBA scoreboards, 24 second cubes, red LED fitted backboards and Olympic standard portable baskets.
        /// 
        /// To book a court at the National Basketball Performance Centre, please use the link below or drop in to one of our Pay & Play sessions."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public override string Description { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override SingleValues<string, PostalAddress> Address { get; set; }

        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override GeoCoordinates Geo { get; set; }

        /// <summary>
        /// An image or photo that depicts the specific SportsActivityLocation.
        /// </summary>
        /// <example>
        /// <code>
        /// "image": [
        ///   {
        ///     "thumbnail": "http://example.com/static/image/speedball_thumbnail.jpg",
        ///     "@type": "ImageObject",
        ///     "url": "http://example.com/static/image/speedball_large.jpg"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "image", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<ImageObject> Image { get; set; }

        /// <summary>
        /// The times the SportsActivityLocation is open
        /// </summary>
        [DataMember(Name = "openingHoursSpecification", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<OpeningHoursSpecification> OpeningHoursSpecification { get; set; }

        /// <summary>
        /// A website URL that describes the SportsActivityLocation
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://www.better.org.uk/leisure-centre/manchester/belle-vue-sports-village/facilities"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public override Uri Url { get; set; }
    }
}
