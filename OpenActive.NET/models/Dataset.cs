
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
    /// This type is derived from [Dataset](https://schema.org/Dataset), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class Dataset : Schema.NET.Dataset
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Dataset";

        
        /// <summary>
        /// The name of the Dataset
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Acme Leisure Sessions and Facilities"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The description of the Dataset
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Near real-time availability and rich descriptions relating to the sessions and facilities available from {OrganisationName}, published using the OpenActive Modelling Specification 2.0."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        public new virtual string Description { get; set; }


        /// <summary>
        /// A background image for the Dataset.
        /// </summary>
        /// <example>
        /// <code>
        /// "backgroundImage": {
        ///   "@type": "ImageObject",
        ///   "url": "http://example.com/static/image/speedball_large.jpg"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "backgroundImage", EmitDefaultValue = false, Order = 9)]
        public virtual ImageObject BackgroundImage { get; set; }


        /// <summary>
        /// Information about the Booking System or publishing platform
        /// </summary>
        [DataMember(Name = "bookingService", EmitDefaultValue = false, Order = 10)]
        public virtual BookingService BookingService { get; set; }


        /// <summary>
        /// The date this Dataset was last updated. For RPDE feeds this may simply be the date and time that the Dataset Site was rendered, which may be cached.
        /// </summary>
        /// <example>
        /// <code>
        /// "dateModified": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "dateModified", EmitDefaultValue = false, Order = 11)]
        public new virtual DateTimeOffset? DateModified { get; set; }


        /// <summary>
        /// The date this Dataset was first published. Can be specified as a schema:Date or schema:DateTime.
        /// </summary>
        /// <example>
        /// <code>
        /// "datePublished": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "datePublished", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, DateTimeOffset?> DatePublished { get; set; }


        /// <summary>
        /// A URL that can be used to raise issues related to the Dataset via a public forum.
        /// </summary>
        /// <example>
        /// <code>
        /// "discussionUrl": "https://github.com/gladstonemrm/FusionLifestyle/issues"
        /// </code>
        /// </example>
        [DataMember(Name = "discussionUrl", EmitDefaultValue = false, Order = 13)]
        public new virtual Uri DiscussionUrl { get; set; }


        /// <summary>
        /// An array of feeds within the dataset
        /// </summary>
        /// <example>
        /// <code>
        /// "distribution": [
        ///   {
        ///     "@type": "DataDownload",
        ///     "name": "FacilityUse",
        ///     "additionalType": "https://openactive.io/FacilityUse",
        ///     "encodingFormat": "application/vnd.openactive.rpde+json; version=1",
        ///     "contentUrl": "https://opendata.leisurecloud.live/api/feeds/fusion-lifestyle-fl-live-facility-uses"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "distribution", EmitDefaultValue = false, Order = 14)]
        public new virtual List<DataDownload> Distribution { get; set; }


        /// <summary>
        /// A link to documentation related to the Dataset, or a link to the OpenActive developer documentation if no Dataset-specific documentation is available.
        /// </summary>
        /// <example>
        /// <code>
        /// "documentation": "https://developer.openactive.io"
        /// </code>
        /// </example>
        [DataMember(Name = "documentation", EmitDefaultValue = false, Order = 15)]
        public virtual Uri Documentation { get; set; }


        /// <summary>
        /// An array of languages included in the Dataset content. Please use one of the language codes from the IETF BCP 47 standard.
        /// </summary>
        /// <example>
        /// <code>
        /// "inLanguage": [
        ///   "en-GB"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "inLanguage", EmitDefaultValue = false, Order = 16)]
        public new virtual List<string> InLanguage { get; set; }


        /// <summary>
        /// Keywords for search engine optimisation
        /// </summary>
        /// <example>
        /// <code>
        /// "keywords": [
        ///   "Sessions",
        ///   "Facilities",
        ///   "Activities",
        ///   "Sports",
        ///   "Physical Activity",
        ///   "OpenActive"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "keywords", EmitDefaultValue = false, Order = 17)]
        public new virtual List<string> Keywords { get; set; }


        /// Must always be present and set to <code>
        /// "license": "https://creativecommons.org/licenses/by/4.0/"
        /// </code>
        [DataMember(Name = "license", EmitDefaultValue = false, Order = 18)]
        public new virtual Uri License { get; set; }


        /// <summary>
        /// The organization ultimately responsible for this Dataset.
        /// </summary>
        /// <example>
        /// <code>
        /// "publisher": {
        ///   "name": "Central Speedball Association",
        ///   "type": "Organization",
        ///   "url": "http://www.speedball-world.com"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "publisher", EmitDefaultValue = false, Order = 19)]
        public new virtual Organization Publisher { get; set; }


        /// <summary>
        /// Indicates the version of OpenActive Modelling Opportunity Data Specification with which this Dataset conforms, by specifying its URL.
        /// </summary>
        /// <example>
        /// <code>
        /// "schemaVersion": "https://www.openactive.io/modelling-opportunity-data/2.0/"
        /// </code>
        /// </example>
        [DataMember(Name = "schemaVersion", EmitDefaultValue = false, Order = 20)]
        public new virtual Uri SchemaVersion { get; set; }


        /// <summary>
        /// The URL of the dataset site.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://opendata.fusion-lifestyle.com/OpenActive/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 21)]
        public new virtual Uri Url { get; set; }

    }
}
