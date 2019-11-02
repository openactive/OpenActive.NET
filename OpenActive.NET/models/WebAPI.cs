
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// ## **EARLY RELEASE NOTICE**
    /// In order to expedite the OpenActive tooling work, this class has been added to the model for the purposes of testing.
    /// IT IS SUBJECT TO CHANGE, as the [Dataset API Discovery specification](https://www.openactive.io/dataset-api-discovery/EditorsDraft/) evolves.
    /// 
    /// This type is derived from [WebAPI](https://pending.schema.org/WebAPI).
    /// </summary>
    [DataContract]
    public partial class WebAPI : Schema.NET.JsonLdObject
    {
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
        public virtual string Name { get; set; }


        /// <summary>
        /// The description of the Dataset
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Near real-time availability and rich descriptions relating to the sessions and facilities available from {OrganisationName}, published using the OpenActive Modelling Specification 2.0."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        public virtual string Description { get; set; }


        /// <summary>
        /// Indicates the version and profiles of OpenActive Open Booking Specification with which this WebAPI conforms, by specifying these as URLs.
        /// </summary>
        /// <example>
        /// <code>
        /// "conformsTo": [
        ///   "https://www.openactive.io/open-booking-api/1.0/#core"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "conformsTo", EmitDefaultValue = false, Order = 9)]
        public virtual List<Uri> ConformsTo { get; set; }


        /// <summary>
        /// A link to documentation related to the Dataset, or a link to the OpenActive developer documentation if no Dataset-specific documentation is available.
        /// </summary>
        /// <example>
        /// <code>
        /// "documentation": "https://developer.openactive.io"
        /// </code>
        /// </example>
        [DataMember(Name = "documentation", EmitDefaultValue = false, Order = 10)]
        public virtual Uri Documentation { get; set; }


        /// <summary>
        /// The Open API document associated with this version of the Open Booking API
        /// </summary>
        /// <example>
        /// <code>
        /// "endpointDescription": "https://www.openactive.io/open-booking-api/1.0/swagger.json"
        /// </code>
        /// </example>
        [DataMember(Name = "endpointDescription", EmitDefaultValue = false, Order = 11)]
        public virtual Uri EndpointDescription { get; set; }


        /// <summary>
        /// The base URL of the Open Booking API
        /// </summary>
        /// <example>
        /// <code>
        /// "endpointURL": "https://example.bookingsystem.com/api/openbooking"
        /// </code>
        /// </example>
        [DataMember(Name = "endpointURL", EmitDefaultValue = false, Order = 12)]
        public virtual Uri EndpointURL { get; set; }


        /// <summary>
        /// The web page the broker uses to obtain access to the API, e.g. via a web form.
        /// </summary>
        /// <example>
        /// <code>
        /// "landingPage": "https://exampleforms.com/get-me-an-api-access-key"
        /// </code>
        /// </example>
        [DataMember(Name = "landingPage", EmitDefaultValue = false, Order = 13)]
        public virtual Uri LandingPage { get; set; }


        /// <summary>
        /// A link to terms of service related to the use of this API.
        /// </summary>
        /// <example>
        /// <code>
        /// "termsOfService": "https://example.bookingsystem.com/terms"
        /// </code>
        /// </example>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 14)]
        public virtual Uri TermsOfService { get; set; }

    }
}
