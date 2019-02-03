
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Place](https://schema.org/Place), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Place : Schema.NET.Place
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Place";

        
        /// <summary>
        /// A structured PostalAddress object for the Place. 
        /// Ideally the address should be provided using the PostalAddress structured format. Google Reserve requires https://schema.org/PostalAddress and will not accept plain text addresses.
        /// </summary>
        /// <example>
        /// <code>
        /// "address": {
        ///   "type": "PostalAddress",
        ///   "streetAddress": "Raynes Park High School, 46A West Barnes Lane",
        ///   "addressLocality": "New Malden",
        ///   "addressRegion": "London",
        ///   "postalCode": "NW5 3DU",
        ///   "addressCountry": "GB"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "address", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<string, PostalAddress> Address { get; set; }


        /// <summary>
        /// An array listing the Ammenities of the Place.
        /// </summary>
        /// <example>
        /// <code>
        /// "amenityFeature": [
        ///   {
        ///     "name": "Changing Facilities",
        ///     "value": true,
        ///     "type": "ChangingFacilities"
        ///   },
        ///   {
        ///     "name": "Showers",
        ///     "value": false,
        ///     "type": "Showers"
        ///   },
        ///   {
        ///     "name": "Lockers",
        ///     "value": true,
        ///     "type": "Lockers"
        ///   },
        ///   {
        ///     "name": "Towels",
        ///     "value": false,
        ///     "type": "Towels"
        ///   },
        ///   {
        ///     "name": "Creche",
        ///     "value": false,
        ///     "type": "Creche"
        ///   },
        ///   {
        ///     "name": "Parking",
        ///     "value": true,
        ///     "type": "Parking"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "amenityFeature", Order = 115)]
        public new virtual List<LocationFeatureSpecification> AmenityFeature { get; set; }


        /// <summary>
        /// The place within which this Place exists
        /// </summary>
        /// <example>
        /// <code>
        /// "containedInPlace": {
        ///   "type": "Place",
        ///   "url": "https://www.everyoneactive.com/centres/Middlesbrough-Sports-Village",
        ///   "name": "Middlesbrough Sports Village"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "containedInPlace", Order = 115)]
        public new virtual Place ContainedInPlace { get; set; }


        /// <summary>
        /// Places that exist within this place
        /// </summary>
        /// <example>
        /// <code>
        /// "containsPlace": {
        ///   "type": "Place",
        ///   "url": "https://www.everyoneactive.com/centres/Center-Parcs-Sports-Plaza",
        ///   "name": "Center Parcs Sports Plaza"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "containsPlace", Order = 115)]
        public new virtual List<Place> ContainsPlace { get; set; }


        /// <summary>
        /// The description of the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Raynes Park High School in London"
        /// </code>
        /// </example>
        [DataMember(Name = "description", Order = 115)]
        public new virtual string Description { get; set; }


        /// <summary>
        /// The geo coordinates of the Place.
        /// </summary>
        /// <example>
        /// <code>
        /// "geo": {
        ///   "latitude": 51.4034423828125,
        ///   "longitude": -0.2369088977575302,
        ///   "type": "GeoCoordinates"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "geo", Order = 115)]
        public new virtual GeoCoordinates Geo { get; set; }


        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// An image or photo that depicts the place, e.g. a photo taken at a previous event.
        /// </summary>
        /// <example>
        /// <code>
        /// "image": [
        ///   {
        ///     "thumbnail": "http://example.com/static/image/speedball_thumbnail.jpg",
        ///     "type": "ImageObject",
        ///     "url": "http://example.com/static/image/speedball_large.jpg"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "image", Order = 115)]
        public new virtual List<ImageObject> Image { get; set; }


        /// <summary>
        /// The name of the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Raynes Park High School"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The times the Place is open
        /// </summary>
        [DataMember(Name = "openingHoursSpecification", Order = 115)]
        public new virtual List<OpeningHoursSpecification> OpeningHoursSpecification { get; set; }


        /// <summary>
        /// The telephone number for the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01253 473934"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", Order = 115)]
        public new virtual string Telephone { get; set; }


        /// <summary>
        /// The website for the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.rphs.org.uk/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", Order = 115)]
        public new virtual Uri Url { get; set; }

    }
}
