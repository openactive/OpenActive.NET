
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
    public partial class Person : Schema.NET.Person
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
        public new virtual SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// A full name for the person. 
        /// This person must have given permission for their personal information to be shared as part of the open data.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Daley Thompson"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
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
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }


        /// <summary>
        /// Address of the Seller, used on tax receipts.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual PostalAddress Address { get; set; }


        /// <summary>
        /// The e-mail address of the person. 
        /// This person must have given permission for their personal information to be shared as part of the open data.
        /// </summary>
        /// <example>
        /// <code>
        /// "email": "jane.smith@example.com"
        /// </code>
        /// </example>
        [DataMember(Name = "email", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Email { get; set; }


        /// <summary>
        /// A last name for the person. 
        /// This person must have given permission for their personal information to be shared as part of the open data.
        /// </summary>
        /// <example>
        /// <code>
        /// "familyName": "Thompson"
        /// </code>
        /// </example>
        [DataMember(Name = "familyName", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string FamilyName { get; set; }


        /// <summary>
        /// Indicates the gender of the person.
        /// </summary>
        /// <example>
        /// <code>
        /// "gender": "https://schema.org/Female"
        /// </code>
        /// </example>
        [DataMember(Name = "gender", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Schema.NET.GenderType? Gender { get; set; }


        /// <summary>
        /// A first name for the person. 
        /// This person must have given permission for their personal information to be shared as part of the open data.
        /// </summary>
        /// <example>
        /// <code>
        /// "givenName": "Daley"
        /// </code>
        /// </example>
        [DataMember(Name = "givenName", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string GivenName { get; set; }


        /// <summary>
        /// The job title of a person 
        /// This person must have given permission for their personal information to be shared as part of the open data.
        /// </summary>
        /// <example>
        /// <code>
        /// "jobTitle": "Team Captain"
        /// </code>
        /// </example>
        [DataMember(Name = "jobTitle", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string JobTitle { get; set; }


        /// <summary>
        /// The official name of the organization, e.g. the registered company name.
        /// </summary>
        /// <example>
        /// <code>
        /// "legalName": "Central Speedball Ltd"
        /// </code>
        /// </example>
        [DataMember(Name = "legalName", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string LegalName { get; set; }


        /// <summary>
        /// A logo for the person.
        /// </summary>
        /// <example>
        /// <code>
        /// "logo": {
        ///   "@type": "ImageObject",
        ///   "url": "http://example.com/static/image/speedball_large.jpg"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "logo", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ImageObject Logo { get; set; }


        /// <summary>
        /// Lists the URL(s) of the official social media profile pages associated with the person.
        /// </summary>
        /// <example>
        /// <code>
        /// "sameAs": "https://example.org/example-org"
        /// </code>
        /// </example>
        [DataMember(Name = "sameAs", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Uri> SameAs { get; set; }


        /// <summary>
        /// Either  https://openactive.io/TaxNet or  https://openactive.io/TaxGross
        /// </summary>
        [DataMember(Name = "taxMode", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual TaxMode? TaxMode { get; set; }


        /// <summary>
        /// The telephone number of the person 
        /// This person must have given permission for their personal information to be shared as part of the open data.
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01234 567890"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Telephone { get; set; }


        /// <summary>
        /// The terms of service of the Seller.
        /// </summary>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Terms> TermsOfService { get; set; }


        /// <summary>
        /// A URL where more information about the person may be found
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.example.com/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 22)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// The Value-added Tax ID of the of the Seller.
        /// </summary>
        [DataMember(Name = "vatID", EmitDefaultValue = false, Order = 23)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string VatID { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// Sometimes a description is stored with formatting (e.g. href, bold, italics, embedded YouTube videos). This formatting can be useful for data consumers.
        /// 
        /// If you are using this property, please join the discussion at proposal [#2](https://github.com/openactive/ns-beta/issues/2).
        /// </summary>
        [DataMember(Name = "beta:formattedDescription", EmitDefaultValue = false, Order = 1024)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string FormattedDescription { get; set; }

    }
}
