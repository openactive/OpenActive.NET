
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// EARLY RELEASE NOTICE: In order to expedite the OpenActive tooling work, this class has been added to the model for the purposes of testing. IT IS SUBJECT TO CHANGE, as the [Dataset API Discovery specification](https://www.openactive.io/dataset-api-discovery/EditorsDraft/) evolves.
    /// 
    /// This type is derived from https://schema.org/DataCatalog, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class DataCatalog : Schema.NET.DataCatalog
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
        public override string Type => "DataCatalog";

        
        /// <summary>
        /// The name of the `DataCatalog`
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Acme Leisure Sessions and Facilities"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The URLs of the dataset sites within this `DataCatalog`.
        /// </summary>
        /// <example>
        /// <code>
        /// "dataset": [
        ///   "https://opendata.exercise-anywhere.com/",
        ///   "https://www.participant.co.uk/participant/openactive/"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "dataset", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<Uri> Dataset { get; set; }


        /// <summary>
        /// The date this `DataCatalog` was last updated.
        /// </summary>
        /// <example>
        /// <code>
        /// "dateModified": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "dateModified", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601DateTimeValuesConverter))]
        public new virtual DateTimeOffset? DateModified { get; set; }


        /// <summary>
        /// The date this `DataCatalog` was first published. Can be specified as a schema:Date or schema:DateTime.
        /// </summary>
        /// <example>
        /// <code>
        /// "datePublished": "2018-01-27T12:00:00Z"
        /// </code>
        /// </example>
        [DataMember(Name = "datePublished", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, DateTimeOffset?> DatePublished { get; set; }


        /// Must always be present and set to <code>
        /// "license": "https://creativecommons.org/licenses/by/4.0/"
        /// </code>
        [DataMember(Name = "license", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri License { get; set; }


        /// <summary>
        /// The organization ultimately responsible for maintaining this `DataCatalog`.
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
        [DataMember(Name = "publisher", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Organization Publisher { get; set; }

    }
}
