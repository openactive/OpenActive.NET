using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/PropertyValue, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class PropertyValue : Schema.NET.PropertyValue
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
        public override string Type => "PropertyValue";

        /// <summary>
        /// The name of this PropertyValue
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Vendor ID"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// Additional human-readable version of the value of the property.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }

        /// <summary>
        /// A commonly used identifier for the characteristic represented by the property
        /// </summary>
        /// <example>
        /// <code>
        /// "propertyID": "https://example.com/photoconsent"
        /// </code>
        /// </example>
        [DataMember(Name = "propertyID", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<string, Uri> PropertyID { get; set; }

        /// <summary>
        /// The actual value of this identifier
        /// </summary>
        /// <example>
        /// <code>
        /// "value": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "value", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<bool?, Uri, string> Value { get; set; }
    }
}
