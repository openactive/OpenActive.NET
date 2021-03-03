
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
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
        /// "altLabel": [
        ///   "Five a side"
        /// ]
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
        /// "broader": [
        ///   "https://openactive.io/activity-list#6ca15167-51da-4d91-a1ae-8a45dc47b0ea"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "broader", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> Broader { get; set; }


        /// <summary>
        /// A human readable string that unambiguously defines the Concept, for use in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "definition": "Latin American style of dance with Cuban origins."
        /// </code>
        /// </example>
        [DataMember(Name = "definition", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Definition { get; set; }


        /// <summary>
        /// An alternative human readable string used to drive autocomplete search matches, that is hidden from the user.
        /// </summary>
        /// <example>
        /// <code>
        /// "hiddenLabel": [
        ///   "5-a-side"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "hiddenLabel", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<string> HiddenLabel { get; set; }


        /// <summary>
        /// A stable URL reference for the taxonomy, which must be `https://openactive.io/activity-list` to reference the OpenActive Activity List.
        /// </summary>
        /// <example>
        /// <code>
        /// "inScheme": "https://openactive.io/activity-list"
        /// </code>
        /// </example>
        [DataMember(Name = "inScheme", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri InScheme { get; set; }


        /// <summary>
        /// A more specific concept URI
        /// </summary>
        /// <example>
        /// <code>
        /// "narrower": [
        ///   "https://openactive.io/activity-list#b3829f3e-a63e-455f-a51c-1f50ecf85ad5"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "narrower", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> Narrower { get; set; }


        /// <summary>
        /// A human-readable identifier for the concept.
        /// </summary>
        /// <example>
        /// <code>
        /// "notation": "salsa"
        /// </code>
        /// </example>
        [DataMember(Name = "notation", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Notation { get; set; }


        /// <summary>
        /// A human readable string that minimally describes the Concept, for use in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "prefLabel": "Salsa"
        /// </code>
        /// </example>
        [DataMember(Name = "prefLabel", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string PrefLabel { get; set; }


        /// <summary>
        /// A related Concept URI
        /// </summary>
        /// <example>
        /// <code>
        /// "related": [
        ///   "https://openactive.io/activity-list#5cdf5ead-e19d-4619-9585-cfe509c3fe52"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "related", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Uri> Related { get; set; }


        /// <summary>
        /// A reference to the Scheme URI, the existence of which indicates that this Concept is at the top level of the hierarchy.
        /// </summary>
        /// <example>
        /// <code>
        /// "topConceptOf": "https://openactive.io/activity-list"
        /// </code>
        /// </example>
        [DataMember(Name = "topConceptOf", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri TopConceptOf { get; set; }

    }
}
