
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from https://schema.org/Thing, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class OpenBookingError : Schema.NET.Thing
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
        public override string Type => "OpenBookingError";

        
        /// <summary>
        /// A short, human-readable summary of the problem type. It should not change from occurrence to occurrence of the problem, except for purposes of localization.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "No customer details supplied"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem, providing specific information about why the error occurred in this particular case.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "No customer details supplied. These must be supplied for calls to C2, P, and B."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }


        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem. It may or may not yield further information if dereferenced.
        /// </summary>
        [DataMember(Name = "instance", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri Instance { get; set; }


        /// <summary>
        /// Used by technical support for diagnostics purposes.
        /// </summary>
        [DataMember(Name = "requestId", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string RequestId { get; set; }


        /// <summary>
        /// An integer representing the HTTP status code.
        /// </summary>
        [DataMember(Name = "statusCode", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? StatusCode { get; set; }

    }
}
