
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Course](https://schema.org/Course), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Course : Schema.NET.Course
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Course";

        
        /// <summary>
        /// Specifies the physical activity or activities that will take place during a Course.
        /// </summary>
        /// <example>
        /// <code>
        /// "activity": [
        ///   {
        ///     "id": "https://openactive.io/activity-list#fbdc35a8-3dd0-40ee-a7ca-6ff40b3e5f90",
        ///     "type": "Concept",
        ///     "prefLabel": "Netball",
        ///     "inScheme": "https://openactive.io/activity-list"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "activity", Order = 115)]
        public virtual List<Concept> Activity { get; set; }


        /// <summary>
        /// The person or organization who have created the Course. An author might be an schema:Organization or a schema:Person.
        /// </summary>
        /// <example>
        /// <code>
        /// "author": {
        ///   "name": "Central Speedball Association",
        ///   "type": "Organization",
        ///   "url": "http://www.speedball-world.com"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "author", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<Person, Organization> Author { get; set; }


        /// <summary>
        /// The description of the Course
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
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// An associated logo for a course.
        /// 
        /// If you are using this property, please join the discussion at proposal [#164](https://github.com/openactive/modelling-opportunity-data/issues/164).
        /// </summary>
        [DataMember(Name = "beta:logo", Order = 115)]
        public virtual ImageObject Logo { get; set; }


        /// <summary>
        /// The name of the Course
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Netball Youth Camp"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A definitive canonical URL for the Course.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.speedball-world.com/beginners-course"
        /// </code>
        /// </example>
        [DataMember(Name = "url", Order = 115)]
        public new virtual Uri Url { get; set; }

    }
}
