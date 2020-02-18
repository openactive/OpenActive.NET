
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/Service, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class BookingService : Schema.NET.Service
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
        public override string Type => "BookingService";

        
        /// <summary>
        /// The name of the Booking System.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The version of the application, useful for on-premise installations. Note this property is in EARLY RELEASE AND IS SUBJECT TO CHANGE, as the [Dataset API Discovery specification](https://www.openactive.io/dataset-api-discovery/EditorsDraft/) evolves.
        /// </summary>
        [DataMember(Name = "softwareVersion", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string SoftwareVersion { get; set; }


        /// <summary>
        /// The terms of service of the Booking System.
        /// </summary>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Terms> TermsOfService { get; set; }


        /// <summary>
        /// The URL of the website of the Booking System.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

    }
}
