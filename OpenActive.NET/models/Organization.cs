
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Organization](https://schema.org/Organization), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Organization : Schema.NET.Organization
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Organization";

        
        /// <summary>
        /// The description of the Organization
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "The national governing body of cycling"
        /// </code>
        /// </example>
        [DataMember(Name = "description", Order = 115)]
        public new virtual string Description { get; set; }


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
        /// A logo for the Organization.
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
        /// The name of the Organization
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Central Speedball Association"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The official name of the organization, e.g. the registered company name.
        /// </summary>
        /// <example>
        /// <code>
        /// "legalName": "Central Speedball Ltd"
        /// </code>
        /// </example>
        [DataMember(Name = "legalName", Order = 115)]
        public new virtual string LegalName { get; set; }


        /// <summary>
        /// General enquiries e-mail address for the organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "email": "info@example.com"
        /// </code>
        /// </example>
        [DataMember(Name = "email", Order = 115)]
        public new virtual string Email { get; set; }


        /// <summary>
        /// Lists the URL(s) of the official social media profile pages associated with the organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "sameAs": [
        ///   "https://www.facebook.com/everyoneactive/",
        ///   "https://twitter.com/everyoneactive"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "sameAs", Order = 115)]
        public new virtual List<Uri> SameAs { get; set; }


        /// <summary>
        /// The telephone number of the Organization
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01234 567890"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", Order = 115)]
        public new virtual string Telephone { get; set; }


        /// <summary>
        /// A definitive canonical URL for the Organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.speedball-world.com"
        /// </code>
        /// </example>
        [DataMember(Name = "url", Order = 115)]
        public new virtual Uri Url { get; set; }

    }
}
