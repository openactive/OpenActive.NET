
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
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// The name of the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Raynes Park High School"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The description of the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Raynes Park High School in London"
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        public new virtual string Description { get; set; }


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
        [DataMember(Name = "amenityFeature", EmitDefaultValue = false, Order = 11)]
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
        [DataMember(Name = "containedInPlace", EmitDefaultValue = false, Order = 12)]
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
        [DataMember(Name = "containsPlace", EmitDefaultValue = false, Order = 13)]
        public new virtual List<Place> ContainsPlace { get; set; }


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
        [DataMember(Name = "geo", EmitDefaultValue = false, Order = 14)]
        public new virtual GeoCoordinates Geo { get; set; }


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
        [DataMember(Name = "image", EmitDefaultValue = false, Order = 15)]
        public new virtual List<ImageObject> Image { get; set; }


        /// <summary>
        /// The times the Place is open
        /// </summary>
        [DataMember(Name = "openingHoursSpecification", EmitDefaultValue = false, Order = 16)]
        public new virtual List<OpeningHoursSpecification> OpeningHoursSpecification { get; set; }


        /// <summary>
        /// The telephone number for the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01253 473934"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", EmitDefaultValue = false, Order = 17)]
        public new virtual string Telephone { get; set; }


        /// <summary>
        /// The website for the Place
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.rphs.org.uk/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 18)]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// Sometimes a description is stored with formatting (e.g. href, bold, italics, embedded YouTube videos). This formatting can be useful for data consumers.
        /// 
        /// If you are using this property, please join the discussion at proposal [#2](https://github.com/openactive/ns-beta/issues/2).
        /// </summary>
        [DataMember(Name = "beta:formattedDescription", EmitDefaultValue = false, Order = 1019)]
        public virtual string FormattedDescription { get; set; }

    }
}
