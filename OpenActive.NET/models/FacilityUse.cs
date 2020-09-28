
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/Product, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class FacilityUse : Schema.NET.Product
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
        public override string Type => "FacilityUse";

        
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
        /// The name of the facility use
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A plain text description of the facility use, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "An fast paced game that incorporates netball, handball and football."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }


        /// <summary>
        /// Provide additional, specific documentation for participants about how disabilities are, or can be supported at the Event.
        /// </summary>
        /// <example>
        /// <code>
        /// "accessibilityInformation": "This route has been British Cycling assessed as an accessible route, meaning it is suitable for the majority of adaptive bikes. The route will have no or low levels of traffic, there will be plenty of space and will have a good surface throughout. If you have any questions about using this route on an adaptive bike on this ride, please use visit https://www.letsride.co.uk/accessibility or call 0123 456 7000 and ask for the Recreation team."
        /// </code>
        /// </example>
        [DataMember(Name = "accessibilityInformation", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AccessibilityInformation { get; set; }


        /// <summary>
        /// Used to specify the types of disabilities or impairments that are supported at an event.
        /// </summary>
        /// <example>
        /// <code>
        /// "accessibilitySupport": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://openactive.io/accessibility-support#1393f2dc-3fcc-4be9-a99f-f1e51f5ad277",
        ///     "prefLabel": "Visual impairment",
        ///     "inScheme": "https://openactive.io/accessibility-support"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "accessibilitySupport", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> AccessibilitySupport { get; set; }


        /// <summary>
        /// Specifies the physical activity or activities that will take place during a facility use.
        /// </summary>
        /// <example>
        /// <code>
        /// "activity": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://openactive.io/activity-list#c0360db0-a817-4bae-9167-40f89b49fc9e",
        ///     "prefLabel": "Badminton",
        ///     "inScheme": "https://openactive.io/activity-list"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "activity", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> Activity { get; set; }


        /// <summary>
        /// Provides additional notes and instructions for users of a facility, for example more information on how to find it, what to bring, etc. The value of this property must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "attendeeInstructions": "The tennis court is locked with a keycode, so please ensure you book online in advance to gain access."
        /// </code>
        /// </example>
        [DataMember(Name = "attendeeInstructions", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AttendeeInstructions { get; set; }


        /// <summary>
        /// Provides a set of tags that help categorise and describe a facility.
        /// </summary>
        /// <example>
        /// <code>
        /// "category": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://example.com/reference/categories#Top%20Club%20Level",
        ///     "inScheme": "https://example.com/reference/categories",
        ///     "prefLabel": "Top Club Level"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "category", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<List<string>, List<Concept>> Category { get; set; }


        /// <summary>
        /// An array of slots of availability of this FacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "event": [
        ///   {
        ///     "@type": "Slot",
        ///     "@id": "http://www.example.org/api/facility-uses/432#/event/2018-03-01T10:00:00Z",
        ///     "startDate": "2018-03-01T11:00:00Z",
        ///     "endDate": "2018-03-01T11:30:00Z",
        ///     "duration": "PT30M",
        ///     "remainingUses": 3,
        ///     "maximumUses": 6
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "event", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Slot> Event { get; set; }


        /// <summary>
        /// The times the facility use is available
        /// </summary>
        [DataMember(Name = "hoursAvailable", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<OpeningHoursSpecification> HoursAvailable { get; set; }


        /// <summary>
        /// An image or photo that depicts the facility use, e.g. a photo taken at a previous event.
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
        [DataMember(Name = "image", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<ImageObject> Image { get; set; }


        /// <summary>
        /// Inverse of the oa:aggregateFacilityUse property. Relates a oa:FacilityUse (e.g. an opportunity to play tennis at a specific location) to an oa:IndividualFacilityUse (e.g. an opportunity to play tennis on a specific court).
        /// </summary>
        /// <example>
        /// <code>
        /// "individualFacilityUse": [
        ///   {
        ///     "@type": "IndividualFacilityUse",
        ///     "@id": "http://www.example.org/facility-uses/1",
        ///     "name": "Tennis Court 1"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "individualFacilityUse", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<IndividualFacilityUse> IndividualFacilityUse { get; set; }


        /// <summary>
        /// The location at which the facility use will take place.
        /// </summary>
        /// <example>
        /// <code>
        /// "location": {
        ///   "@type": "Place",
        ///   "address": {
        ///     "addressLocality": "New Malden",
        ///     "addressRegion": "London",
        ///     "postalCode": "NW5 3DU",
        ///     "streetAddress": "Raynes Park High School, 46A West Barnes Lane",
        ///     "@type": "PostalAddress"
        ///   },
        ///   "description": "Raynes Park High School in London",
        ///   "geo": {
        ///     "latitude": 51.4034423828125,
        ///     "longitude": -0.2369088977575302,
        ///     "@type": "GeoCoordinates"
        ///   },
        ///   "@id": "https://example.com/locations/1234ABCD",
        ///   "identifier": "1234ABCD",
        ///   "name": "Raynes Park High School",
        ///   "telephone": "01253 473934"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "location", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Place Location { get; set; }


        /// <summary>
        /// An array of schema:Offer that include the price of booking.
        /// </summary>
        /// <example>
        /// <code>
        /// "offers": {
        ///   "@type": "Offer",
        ///   "identifier": "OX-AD",
        ///   "name": "Adult",
        ///   "price": 7.5,
        ///   "priceCurrency": "GBP",
        ///   "url": "https://profile.everyoneactive.com/booking?Site=0140&Activities=1402CBP20150217&Culture=en-GB"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "offers", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Offer> Offers { get; set; }


        /// <summary>
        /// The organisation responsible for providing the facility
        /// </summary>
        /// <example>
        /// <code>
        /// "provider": {
        ///   "name": "Central Speedball Association",
        ///   "@type": "Organization",
        ///   "url": "http://www.speedball-world.com"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "provider", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Organization Provider { get; set; }


        /// <summary>
        /// A URL to a web page (or section of a page) that describes the facility use.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://example.com/facility-use/1234"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 22)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Sometimes a description is stored with formatting (e.g. href, bold, italics, embedded YouTube videos). This formatting can be useful for data consumers. This property must contain HTML.
        /// 
        /// If you are using this property, please join the discussion at proposal [#2](https://github.com/openactive/ns-beta/issues/2).
        /// </summary>
        [DataMember(Name = "beta:formattedDescription", EmitDefaultValue = false, Order = 1023)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string FormattedDescription { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A property that details whether the event is suitable for wheelchair access. Placed on Event as this field could be used to detail whether the Event is suitable, as well as the Place.
        /// 
        /// If you are using this property, please join the discussion at proposal [#166](https://github.com/openactive/modelling-opportunity-data/issues/166).
        /// </summary>
        [DataMember(Name = "beta:isWheelchairAccessible", EmitDefaultValue = false, Order = 1024)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsWheelchairAccessible { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A related video object.
        /// 
        /// If you are using this property, please join the discussion at proposal [#88](https://github.com/openactive/modelling-opportunity-data/issues/88).
        /// </summary>
        [DataMember(Name = "beta:video", EmitDefaultValue = false, Order = 1025)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<VideoObject> Video { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Internal location of the event, e.g. Court 1
        /// 
        /// If you are using this property, please join the discussion at proposal [#110](https://github.com/openactive/modelling-opportunity-data/issues/110).
        /// </summary>
        [DataMember(Name = "beta:sportsActivityLocation", EmitDefaultValue = false, Order = 1026)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Schema.NET.SportsActivityLocation> SportsActivityLocation { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Duration before the event for which the associated Offers are valid
        /// 
        /// If you are using this property, please join the discussion at proposal [#204](https://github.com/openactive/modelling-opportunity-data/issues/204).
        /// </summary>
        [DataMember(Name = "beta:offerValidityPeriod", EmitDefaultValue = false, Order = 1027)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? OfferValidityPeriod { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// The type of facility in use.
        /// 
        /// If you are using this property, please join the discussion at proposal [#1](https://github.com/openactive/facility-types/issues/1).
        /// </summary>
        [DataMember(Name = "beta:facilityType", EmitDefaultValue = false, Order = 1028)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> FacilityType { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Whether the event or facility is indoor or outdoor.
        /// 
        /// If you are using this property, please join the discussion at proposal [#1](https://github.com/openactive/facility-types/issues/1).
        /// </summary>
        [DataMember(Name = "beta:facilitySetting", EmitDefaultValue = false, Order = 1029)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual FacilitySettingType? FacilitySetting { get; set; }

    }
}
