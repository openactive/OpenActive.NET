using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Course, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Course : Schema.NET.Course
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
        public override string Type => "Course";

        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "BR1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }

        /// <summary>
        /// The name of the Course
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Netball Youth Camp"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the Course, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Netball Youth Camps give junior netballers the chance to get together with their friends and take to the court in the holidays!
        /// 
        /// The camp is a non-residential holiday camp providing ‘Nothing but Netball’; not only will there be top quality coaching and fun netball activities but there is even an opportunity to meet and be inspired by an elite player.
        /// 
        /// If you are a junior netball lover (or the parent of one!) these are an unmissable holiday activity."
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
        /// Specifies the physical activity or activities that will take place during a Course.
        /// </summary>
        /// <example>
        /// <code>
        /// "activity": [
        ///   {
        ///     "@id": "https://openactive.io/activity-list#fbdc35a8-3dd0-40ee-a7ca-6ff40b3e5f90",
        ///     "@type": "Concept",
        ///     "prefLabel": "Netball",
        ///     "inScheme": "https://openactive.io/activity-list"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "activity", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> Activity { get; set; }

        /// <summary>
        /// Indicates that an event is recommended as being suitable for or is targetted at a specific age range.
        /// </summary>
        /// <example>
        /// <code>
        /// "ageRange": {
        ///   "@type": "QuantitativeValue",
        ///   "minValue": 50,
        ///   "maxValue": 60
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "ageRange", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue AgeRange { get; set; }

        /// <summary>
        /// The person or organization who designed the Course. An author might be an schema:Organization or a schema:Person.
        /// This property may reference the `@id` of the `organizer` of the `CourseInstance` within which this `Course` is embedded, to reduce data duplication.
        /// </summary>
        /// <example>
        /// <code>
        /// "author": {
        ///   "@type": "Organization",
        ///   "@id": "https://id.bookingsystem.example.com/organizers/1",
        ///   "name": "Central Speedball Association",
        ///   "url": "http://www.speedball-world.com"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "author", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ReferenceValue<ILegalEntity> Author { get; set; }

        /// <summary>
        /// Provides a set of tags that help categorise and describe an event, e.g. its intensity, purpose, etc.
        /// </summary>
        /// <example>
        /// <code>
        /// "category": [
        ///   "High Intensity"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "category", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<List<string>, List<Concept>> Category { get; set; }

        /// <summary>
        /// Indicates that an event is restricted to male, female or a mixed audience. This information must be displayed prominently to the user before booking. If a gender restriction isn't specified then applications should assume that an event is suitable for a mixed audience.
        /// </summary>
        /// <example>
        /// <code>
        /// "genderRestriction": "https://openactive.io/FemaleOnly"
        /// </code>
        /// </example>
        [DataMember(Name = "genderRestriction", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual GenderRestrictionType? GenderRestriction { get; set; }

        /// <summary>
        /// An image or photo that depicts the event, e.g. a photo taken at a previous event.
        /// </summary>
        /// <example>
        /// <code>
        /// "image": [
        ///   {
        ///     "@type": "ImageObject",
        ///     "url": "http://example.com/static/image/speedball_large.jpg",
        ///     "thumbnail": [
        ///       {
        ///         "@type": "ImageObject",
        ///         "url": "http://example.com/static/image/speedball_thumbnail.jpg"
        ///       }
        ///     ]
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "image", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<ImageObject> Image { get; set; }

        /// <summary>
        /// A general purpose property for specifying the suitability of an event for different participant “levels”. E.g. `Beginner`, `Intermediate`, `Advanced`. Or in the case of martial arts, specific belt requirements.
        /// </summary>
        /// <example>
        /// <code>
        /// "level": [
        ///   "Beginner"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "level", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual SingleValues<List<string>, List<Concept>> Level { get; set; }

        /// <summary>
        /// A definitive canonical URL for the Course.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.speedball-world.com/beginners-course"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A related video object.
        /// 
        /// If you are using this property, please join the discussion at proposal [#88](https://github.com/openactive/modelling-opportunity-data/issues/88).
        /// </summary>
        [DataMember(Name = "beta:video", EmitDefaultValue = false, Order = 1020)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<VideoObject> Video { get; set; }
    }
}
