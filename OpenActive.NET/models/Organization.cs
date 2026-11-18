using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Organization, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Organization : Schema.NET.Organization
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
        public override string Type => "Organization";

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
        /// The name of the Organization
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Central Speedball Association"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the Organization, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "The national governing body of cycling"
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }

        /// <summary>
        /// The physical activity or activities provided by this organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "activity": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://openactive.io/activity-list#6bb8b844-df3e-4cae-bf5f-3e129c6b1a9d",
        ///     "prefLabel": "Sailing",
        ///     "inScheme": "https://openactive.io/activity-list"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "activity", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> Activity { get; set; }

        /// <summary>
        /// Address of the Seller, used on tax receipts.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual PostalAddress Address { get; set; }

        /// <summary>
        /// The age range this organization caters for overall.
        /// </summary>
        /// <example>
        /// <code>
        /// "ageRange": {
        ///   "@type": "QuantitativeValue",
        ///   "minValue": 5,
        ///   "maxValue": 16
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "ageRange", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue AgeRange { get; set; }

        /// <summary>
        /// Aliases, common acronyms or alternative names for the organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "alternateName": [
        ///   "EYC"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "alternateName", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<List<string>, string> AlternateName { get; set; }

        /// <summary>
        /// General enquiries e-mail address for the organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "email": "info@example.com"
        /// </code>
        /// </example>
        [DataMember(Name = "email", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Email { get; set; }

        /// <summary>
        /// Indicates that the organization provides activities that are restricted to male or female participants, or that there are no restrictions.
        /// </summary>
        /// <example>
        /// <code>
        /// "genderRestriction": "https://openactive.io/FemaleOnly"
        /// </code>
        /// </example>
        [DataMember(Name = "genderRestriction", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual GenderRestrictionType? GenderRestriction { get; set; }

        /// <summary>
        /// Reference to the CustomerAccount associated with this Customer, for use within the Open Booking API flow.
        /// Note that this property is in EARLY RELEASE AND IS SUBJECT TO CHANGE, as the [Customer Accounts proposal](https://github.com/openactive/customer-accounts) evolves.
        /// </summary>
        [DataMember(Name = "hasAccount", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual ReferenceValue<CustomerAccount> HasAccount { get; set; }

        /// <summary>
        /// Indicates whether the Seller allows open booking or not
        /// </summary>
        /// <example>
        /// <code>
        /// "isOpenBookingAllowed": "true"
        /// </code>
        /// </example>
        [DataMember(Name = "isOpenBookingAllowed", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? IsOpenBookingAllowed { get; set; }

        /// <summary>
        /// The official name of the organization, e.g. the registered company name.
        /// </summary>
        /// <example>
        /// <code>
        /// "legalName": "Central Speedball Ltd"
        /// </code>
        /// </example>
        [DataMember(Name = "legalName", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string LegalName { get; set; }

        /// <summary>
        /// Reference to the license under which the Organization's data is published. Required when an Organization is published on its own outside an RPDE feed; in an RPDE feed, the license is given by each feed page, so it should not be included.
        /// </summary>
        /// <example>
        /// <code>
        /// "license": "https://creativecommons.org/licenses/by/4.0/"
        /// </code>
        /// </example>
        [DataMember(Name = "license", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri License { get; set; }

        /// <summary>
        /// The main address of the organization, or the key locations of the activities it provides.
        /// </summary>
        /// <example>
        /// <code>
        /// "location": {
        ///   "@type": "Place",
        ///   "@id": "https://example.com/locations/1234ABCD",
        ///   "name": "Example Sailing Club",
        ///   "address": {
        ///     "@type": "PostalAddress",
        ///     "postalCode": "SE10 0BW",
        ///     "addressCountry": "GB"
        ///   }
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "location", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, List<Place>, PostalAddress, Place> Location { get; set; }

        /// <summary>
        /// A logo for the Organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "logo": {
        ///   "@type": "ImageObject",
        ///   "url": "http://example.com/static/image/speedball_large.jpg"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "logo", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ImageObject Logo { get; set; }

        /// <summary>
        /// The `@id`s of organizations affiliated to this organization. For example, a national governing body can list its affiliated clubs.
        /// </summary>
        /// <example>
        /// <code>
        /// "member": [
        ///   "https://example.org/id/organisation/1"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "member", EmitDefaultValue = false, Order = 22)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<Uri, List<Uri>> Member { get; set; }

        /// <summary>
        /// The `@id` of an organization that this organization is affiliated to. For example, a club can link to its national governing body.
        /// </summary>
        /// <example>
        /// <code>
        /// "memberOf": "https://example.org/id/organisation/national-governing-body"
        /// </code>
        /// </example>
        [DataMember(Name = "memberOf", EmitDefaultValue = false, Order = 23)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ReferenceValue<Organization> MemberOf { get; set; }

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
        [DataMember(Name = "sameAs", EmitDefaultValue = false, Order = 24)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Uri> SameAs { get; set; }

        /// <summary>
        /// Either  https://openactive.io/TaxNet or  https://openactive.io/TaxGross
        /// </summary>
        [DataMember(Name = "taxMode", EmitDefaultValue = false, Order = 25)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual TaxMode? TaxMode { get; set; }

        /// <summary>
        /// The telephone number of the Organization
        /// </summary>
        /// <example>
        /// <code>
        /// "telephone": "01234 567890"
        /// </code>
        /// </example>
        [DataMember(Name = "telephone", EmitDefaultValue = false, Order = 26)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Telephone { get; set; }

        /// <summary>
        /// The terms of service of the Seller.
        /// </summary>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 27)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Terms> TermsOfService { get; set; }

        /// <summary>
        /// A definitive canonical URL for the Organization.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.speedball-world.com"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 28)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

        /// <summary>
        /// The Value-added Tax ID of the of the Seller.
        /// </summary>
        [DataMember(Name = "vatID", EmitDefaultValue = false, Order = 29)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string VatID { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Sometimes a description is stored with formatting (e.g. href, bold, italics, embedded YouTube videos). This formatting can be useful for data consumers. This property must contain HTML.
        /// 
        /// If you are using this property, please join the discussion at proposal [#276](https://github.com/openactive/modelling-opportunity-data/issues/276).
        /// </summary>
        [DataMember(Name = "beta:formattedDescription", EmitDefaultValue = false, Order = 1030)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string FormattedDescription { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// A related video object.
        /// 
        /// If you are using this property, please join the discussion at proposal [#88](https://github.com/openactive/modelling-opportunity-data/issues/88).
        /// </summary>
        [DataMember(Name = "beta:video", EmitDefaultValue = false, Order = 1031)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<VideoObject> Video { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// An array of URLs, each of which describe the formal criteria that are met by the organizer.
        /// 
        /// If you are using this property, please join the discussion at proposal [#236](https://github.com/openactive/modelling-opportunity-data/issues/236).
        /// </summary>
        [DataMember(Name = "beta:formalCriteriaMet", EmitDefaultValue = false, Order = 1032)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> FormalCriteriaMet { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// The date on which the details of this organization were last verified as correct by the publisher. Unlike `schema:dateModified`, this changes when the details are confirmed, even if nothing in them has changed.
        /// 
        /// If you are using this property, please join the discussion at proposal [#313](https://github.com/openactive/modelling-opportunity-data/issues/313).
        /// </summary>
        [DataMember(Name = "beta:dateVerified", EmitDefaultValue = false, Order = 1033)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public virtual DateValue DateVerified { get; set; }
    }
}
