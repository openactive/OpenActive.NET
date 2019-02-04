
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Person](https://schema.org/Person), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Person : Schema.NET.Person
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Person";

        
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
        /// A full name for the person. 
        /// This person must give direct permission for their personal information to be shared as part of the Open Data.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Daley Thompson"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The description of the Person
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "The leader of the coaching team"
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        public new virtual string Description { get; set; }


        /// <summary>
        /// A last name for the person. 
        /// This person must give direct permission for their personal information to be shared as part of the Open Data.
        /// </summary>
        /// <example>
        /// <code>
        /// "familyName": "Thompson"
        /// </code>
        /// </example>
        [DataMember(Name = "familyName", EmitDefaultValue = false, Order = 10)]
        public new virtual string FamilyName { get; set; }


        /// <summary>
        /// Indicates the gender of the person.
        /// </summary>
        /// <example>
        /// <code>
        /// "gender": "https://schema.org/Female"
        /// </code>
        /// </example>
        [DataMember(Name = "gender", EmitDefaultValue = false, Order = 11)]
        public new virtual Schema.NET.GenderType? Gender { get; set; }


        /// <summary>
        /// A first name for the person. 
        /// This person must give direct permission for their personal information to be shared as part of the Open Data.
        /// </summary>
        /// <example>
        /// <code>
        /// "givenName": "Daley"
        /// </code>
        /// </example>
        [DataMember(Name = "givenName", EmitDefaultValue = false, Order = 12)]
        public new virtual string GivenName { get; set; }


        /// <summary>
        /// A logo for the person.
        /// </summary>
        /// <example>
        /// <code>
        /// "logo": {
        ///   "type": "ImageObject",
        ///   "url": "http://example.com/static/image/speedball_large.jpg"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "logo", EmitDefaultValue = false, Order = 13)]
        public new virtual ImageObject Logo { get; set; }


        /// <summary>
        /// Lists the URL(s) of the official social media profile pages associated with the person.
        /// </summary>
        /// <example>
        /// <code>
        /// "sameAs": "https://example.org/example-org"
        /// </code>
        /// </example>
        [DataMember(Name = "sameAs", EmitDefaultValue = false, Order = 14)]
        public new virtual List<Uri> SameAs { get; set; }


        /// <summary>
        /// The telephone number of the person
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01234 567890"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", EmitDefaultValue = false, Order = 15)]
        public new virtual string Telephone { get; set; }


        /// <summary>
        /// A URL where more information about the person may be found
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.example.com/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 16)]
        public new virtual Uri Url { get; set; }

    }
}
