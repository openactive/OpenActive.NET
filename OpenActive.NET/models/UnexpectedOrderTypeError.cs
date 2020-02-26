
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// Error Use Case: The `@type` of the JSON-LD object submitted to the endpoint did not match the expected `@type`, as defined in the Open Booking API specification.
    /// 
    /// This type is derived from https://schema.org/Thing, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class UnexpectedOrderTypeError : OpenBookingError
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
        public override string Type => "UnexpectedOrderTypeError";

        
        /// <summary>
        /// A short, human-readable summary of the problem type. It should not change from occurrence to occurrence of the problem, except for purposes of localization.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "The '@type' of the JSON-LD object submitted to the endpoint did not match the expected '@type', as defined in the Open Booking API specification."
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public override string Name { get; set; } = "The '@type' of the JSON-LD object submitted to the endpoint did not match the expected '@type', as defined in the Open Booking API specification.";


        /// Must always be present and set to <code>
        /// "statusCode": 500
        /// </code>
        [DataMember(Name = "statusCode", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public override long? StatusCode { get; set; } = 500;

    }
}
