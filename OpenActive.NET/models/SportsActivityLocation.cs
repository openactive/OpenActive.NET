using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>	
    /// 	
    /// This type is derived from https://schema.org/SportsActivityLocation, which means that any of this type's properties within schema.org may also be used.	
    /// </summary>	
    [DataContract]
    public partial class SportsActivityLocation : Schema.NET.SportsActivityLocation
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
        public override string Type => "SportsActivityLocation";

        /// <summary>	
        /// While a `url` is not specified as an option in the Modelling Specification, it is necessary to link entities in RPDE.	
        /// </summary>	
        /// <example>	
        /// <code>	
        /// "containedInPlace": "http://www.example.org/api/locations/8958f9b8-2004-4e90-80ff-50c98a9b121d"	
        /// </code>	
        /// </example>	
        [DataMember(Name = "containedInPlace", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<Uri, Place> ContainedInPlace { get; set; }

    }
}