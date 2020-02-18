
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// Error Use Case: The Order UUID used for an `OrderQuote` already represents a completed `Order` with a different set of `OrderItem`s to those specified (note call to B is idempotent for the case where `OrderItem`s match). This happens in the rare event of a Order UUID clash.
    /// 
    /// This type is derived from https://schema.org/Thing, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class OrderAlreadyExistsError : OpenBookingError
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
        public override string Type => "OrderAlreadyExistsError";

        
        /// <summary>
        /// A short, human-readable summary of the problem type. It should not change from occurrence to occurrence of the problem, except for purposes of localization.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "The Order UUID used for an 'OrderQuote' already represents a completed 'Order' with a different set of 'OrderItem's to those specified (note call to B is idempotent for the case where 'OrderItem's match). This happens in the rare event of a Order UUID clash."
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public override string Name { get; set; } = "The Order UUID used for an 'OrderQuote' already represents a completed 'Order' with a different set of 'OrderItem's to those specified (note call to B is idempotent for the case where 'OrderItem's match). This happens in the rare event of a Order UUID clash.";


        /// Must always be present and set to <code>
        /// "statusCode": 500
        /// </code>
        [DataMember(Name = "statusCode", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public override long? StatusCode { get; set; } = 500;

    }
}
