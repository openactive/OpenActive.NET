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
    /// This type is derived from https://schema.org/DataDownload, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class DataDownload : Schema.NET.DataDownload
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
        public override string Type => "DataDownload";

        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "ScheduledSession"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Identifier { get; set; }

        /// <summary>
        /// The name of the type of feed
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "SessionSeries"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// A fully qualified reference to the class that is at the root of the items in the RPDE feed.
        /// </summary>
        /// <example>
        /// <code>
        /// "additionalType": "https://openactive.io/SessionSeries"
        /// </code>
        /// </example>
        [DataMember(Name = "additionalType", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri AdditionalType { get; set; }

        /// <summary>
        /// The URL of the RPDE data feed.
        /// </summary>
        /// <example>
        /// <code>
        /// "contentUrl": "https://opendata.leisurecloud.live/api/feeds/fusion-lifestyle-fl-live-session-series"
        /// </code>
        /// </example>
        [DataMember(Name = "contentUrl", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri ContentUrl { get; set; }

        /// <summary>
        /// Must always be present and set to <code>
        /// "encodingFormat": "application/vnd.openactive.rpde+json; version=1"
        /// </code>
        /// </summary>
        /// <example>
        /// <code>
        /// "encodingFormat": "application/vnd.openactive.rpde+json; version=1"
        /// </code>
        /// </example>
        [DataMember(Name = "encodingFormat", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string EncodingFormat { get; set; }
    }
}
