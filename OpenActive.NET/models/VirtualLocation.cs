using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://pending.schema.org/VirtualLocation.
    /// </summary>
    [DataContract]
    public partial class VirtualLocation : Schema.NET.JsonLdObject
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
        public override string Type => "VirtualLocation";

        /// <summary>
        /// The name of the service that is providing remote access to the Opportunity.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Zoom"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the live stream, including any instructions to join. This description must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Please log into Zoom a few minutes before the event, and mute your mic while you wait for the session to start."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Description { get; set; }

        /// <summary>
        /// The password or pin required to access the `VirtualLocation` from any device, without requiring the URL, e.g. the meeting password.
        /// </summary>
        /// <example>
        /// <code>
        /// "accessCode": "211277"
        /// </code>
        /// </example>
        [DataMember(Name = "accessCode", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AccessCode { get; set; }

        /// <summary>
        /// The identifier required to access the `VirtualLocation` from any device, without requiring the URL, e.g. the meeting ID.
        /// </summary>
        /// <example>
        /// <code>
        /// "accessId": "123456789"
        /// </code>
        /// </example>
        [DataMember(Name = "accessId", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AccessId { get; set; }

        /// <summary>
        /// The URL that enables remote access to the Opportunity, which should include encoded access credentials where possible.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://zoom.us/room/3fbCs0GVjgQ"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri Url { get; set; }
    }
}
