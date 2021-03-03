using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Place, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Place : Schema.NET.Place
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
        public override string Type => "Place";

        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }

        /// <summary>
        /// The name of the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Raynes Park High School"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the Place, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Raynes Park High School in London"
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }

        /// <summary>
        /// A structured PostalAddress object for the Place.
        /// Ideally the address should be provided using the PostalAddress structured format. Google Reserve requires https://schema.org/PostalAddress and will not accept plain text addresses.
        /// </summary>
        /// <example>
        /// <code>
        /// "address": {
        ///   "@type": "PostalAddress",
        ///   "streetAddress": "Raynes Park High School, 46A West Barnes Lane",
        ///   "addressLocality": "New Malden",
        ///   "addressRegion": "London",
        ///   "postalCode": "NW5 3DU",
        ///   "addressCountry": "GB"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "address", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, PostalAddress> Address { get; set; }

        /// <summary>
        /// An array listing the Ammenities of the Place.
        /// </summary>
        /// <example>
        /// <code>
        /// "amenityFeature": [
        ///   {
        ///     "name": "Changing Facilities",
        ///     "value": true,
        ///     "@type": "ChangingFacilities"
        ///   },
        ///   {
        ///     "name": "Showers",
        ///     "value": false,
        ///     "@type": "Showers"
        ///   },
        ///   {
        ///     "name": "Lockers",
        ///     "value": true,
        ///     "@type": "Lockers"
        ///   },
        ///   {
        ///     "name": "Towels",
        ///     "value": false,
        ///     "@type": "Towels"
        ///   },
        ///   {
        ///     "name": "Creche",
        ///     "value": false,
        ///     "@type": "Creche"
        ///   },
        ///   {
        ///     "name": "Parking",
        ///     "value": true,
        ///     "@type": "Parking"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "amenityFeature", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<LocationFeatureSpecification> AmenityFeature { get; set; }

        /// <summary>
        /// The place within which this Place exists
        /// </summary>
        /// <example>
        /// <code>
        /// "containedInPlace": {
        ///   "@type": "Place",
        ///   "url": "https://www.everyoneactive.com/centres/Middlesbrough-Sports-Village",
        ///   "name": "Middlesbrough Sports Village"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "containedInPlace", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Place ContainedInPlace { get; set; }

        /// <summary>
        /// Places that exist within this place
        /// </summary>
        /// <example>
        /// <code>
        /// "containsPlace": {
        ///   "@type": "Place",
        ///   "url": "https://www.everyoneactive.com/centres/Center-Parcs-Sports-Plaza",
        ///   "name": "Center Parcs Sports Plaza"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "containsPlace", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Place> ContainsPlace { get; set; }

        /// <summary>
        /// The geo coordinates of the Place.
        /// </summary>
        /// <example>
        /// <code>
        /// "geo": {
        ///   "latitude": 51.4034423828125,
        ///   "longitude": -0.2369088977575302,
        ///   "@type": "GeoCoordinates"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "geo", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual GeoCoordinates Geo { get; set; }

        /// <summary>
        /// An image or photo that depicts the place, e.g. a photo taken at a previous event.
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
        [DataMember(Name = "image", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<ImageObject> Image { get; set; }

        /// <summary>
        /// The times the Place is open
        /// </summary>
        [DataMember(Name = "openingHoursSpecification", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<OpeningHoursSpecification> OpeningHoursSpecification { get; set; }

        /// <summary>
        /// Explicitly override general opening hours brought in scope by `schema:openingHoursSpecification`.
        /// </summary>
        [DataMember(Name = "specialOpeningHoursSpecification", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<OpeningHoursSpecification> SpecialOpeningHoursSpecification { get; set; }

        /// <summary>
        /// The telephone number for the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01253 473934"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Telephone { get; set; }

        /// <summary>
        /// The website for the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.rphs.org.uk/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Sometimes a description is stored with formatting (e.g. href, bold, italics, embedded YouTube videos). This formatting can be useful for data consumers. This property must contain HTML.
        /// 
        /// If you are using this property, please join the discussion at proposal [#2](https://github.com/openactive/ns-beta/issues/2).
        /// </summary>
        [DataMember(Name = "beta:formattedDescription", EmitDefaultValue = false, Order = 1020)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string FormattedDescription { get; set; }
    }
}
