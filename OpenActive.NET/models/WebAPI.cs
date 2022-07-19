using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// EARLY RELEASE NOTICE: This class represents a draft that is designed to inform the OpenActive specification work with implementation feedback. IT IS SUBJECT TO CHANGE, as the [Dataset API Discovery specification](https://openactive.io/dataset-api-discovery/EditorsDraft/) evolves.
    /// 
    /// This type is derived from https://pending.schema.org/WebAPI.
    /// </summary>
    [DataContract]
    public partial class WebAPI : Schema.NET.JsonLdObject
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
        public override string Type => "WebAPI";

        /// <summary>
        /// The name of the WebAPI
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Acme Leisure Sessions and Facilities"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the Dataset, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Near real-time availability and rich descriptions relating to the sessions and facilities available from {OrganisationName}, published using the OpenActive Modelling Specification 2.0."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Description { get; set; }

        /// <summary>
        /// The location of the OpenID Provider that must be used to access the API.
        /// </summary>
        /// <example>
        /// <code>
        /// "authenticationAuthority": "https://auth.bookingsystem.com"
        /// </code>
        /// </example>
        [DataMember(Name = "authenticationAuthority", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri AuthenticationAuthority { get; set; }

        /// <summary>
        /// Indicates the version and profiles of OpenActive Open Booking Specification with which this WebAPI conforms, by specifying these as URLs.
        /// </summary>
        /// <example>
        /// <code>
        /// "conformsTo": [
        ///   "https://openactive.io/open-booking-api/1.0/#core"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "conformsTo", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> ConformsTo { get; set; }

        /// <summary>
        /// A link to documentation related to how to use the Open Booking API, or a link to the OpenActive developer documentation using `https://permalink.openactive.io/dataset-site/open-booking-api-documentation` if no system-specific documentation is available.
        /// </summary>
        /// <example>
        /// <code>
        /// "documentation": "https://permalink.openactive.io/dataset-site/open-booking-api-documentation"
        /// </code>
        /// </example>
        [DataMember(Name = "documentation", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri Documentation { get; set; }

        /// <summary>
        /// The Open API document associated with this version of the Open Booking API
        /// </summary>
        /// <example>
        /// <code>
        /// "endpointDescription": "https://openactive.io/open-booking-api/1.0/swagger.json"
        /// </code>
        /// </example>
        [DataMember(Name = "endpointDescription", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri EndpointDescription { get; set; }

        /// <summary>
        /// The Base URI of this implementation of the Open Booking API
        /// </summary>
        /// <example>
        /// <code>
        /// "endpointUrl": "https://example.bookingsystem.com/api/openbooking"
        /// </code>
        /// </example>
        [DataMember(Name = "endpointUrl", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri EndpointUrl { get; set; }

        /// <summary>
        /// The URL of a web page that the Broker may use to obtain access to the API, e.g. via a web form.
        /// </summary>
        /// <example>
        /// <code>
        /// "landingPage": "https://exampleforms.com/get-me-an-api-access-key"
        /// </code>
        /// </example>
        [DataMember(Name = "landingPage", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri LandingPage { get; set; }

        /// <summary>
        /// A link to terms of service related to the use of this API.
        /// </summary>
        /// <example>
        /// <code>
        /// "termsOfService": "https://example.bookingsystem.com/terms"
        /// </code>
        /// </example>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri TermsOfService { get; set; }
    }
}
