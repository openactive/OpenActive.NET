
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
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
        [DataMember(Name = "activity", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> Activity { get; set; }


        /// <summary>
        /// The person or organization who have created the Course. An author might be an schema:Organization or a schema:Person.
        /// </summary>
        /// <example>
        /// <code>
        /// "author": {
        ///   "name": "Central Speedball Association",
        ///   "@type": "Organization",
        ///   "url": "http://www.speedball-world.com"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "author", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ILegalEntity Author { get; set; }


        /// <summary>
        /// A definitive canonical URL for the Course.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.speedball-world.com/beginners-course"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// An associated logo for a course.
        /// 
        /// If you are using this property, please join the discussion at proposal [#164](https://github.com/openactive/modelling-opportunity-data/issues/164).
        /// </summary>
        [DataMember(Name = "beta:logo", EmitDefaultValue = false, Order = 1013)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual ImageObject Logo { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A related video object.
        /// 
        /// If you are using this property, please join the discussion at proposal [#88](https://github.com/openactive/modelling-opportunity-data/issues/88).
        /// </summary>
        [DataMember(Name = "beta:video", EmitDefaultValue = false, Order = 1014)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<VideoObject> Video { get; set; }

    }
}
