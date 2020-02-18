
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from http://www.w3.org/2004/02/skos/core#Concept.
    /// </summary>
    [DataContract]
    public partial class Concept : Schema.NET.JsonLdObject
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
        public override string Type => "Concept";

        
        /// <summary>
        /// An alternative human readable string for use in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "altLabel": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "altLabel", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<string> AltLabel { get; set; }


        /// <summary>
        /// A broader Concept URI
        /// </summary>
        /// <example>
        /// <code>
        /// "broader": "https://example.com/football"
        /// </code>
        /// </example>
        [DataMember(Name = "broader", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> Broader { get; set; }


        /// <summary>
        /// A stable URL reference for the taxonomy.
        /// </summary>
        /// <example>
        /// <code>
        /// "inScheme": "https://example.com/reference/activities"
        /// </code>
        /// </example>
        [DataMember(Name = "inScheme", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri InScheme { get; set; }


        /// <summary>
        /// A more specific concept URI
        /// </summary>
        /// <example>
        /// <code>
        /// "narrower": "https://example.com/walking-football"
        /// </code>
        /// </example>
        [DataMember(Name = "narrower", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> Narrower { get; set; }


        /// <summary>
        /// A concept label that is not normally recognisable as natural language.
        /// </summary>
        /// <example>
        /// <code>
        /// "notation": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "notation", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Notation { get; set; }


        /// <summary>
        /// A human readable string for use in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "prefLabel": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "prefLabel", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string PrefLabel { get; set; }

    }
}
