
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
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
        /// The name of the livestream.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Zoom Room"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string Name { get; set; }


        /// <summary>
        /// A free text description of the livestream, including any instructions to join.
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
        /// The URL for the livestream.
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "https://zoom.us/room/3fbCs0GVjgQ"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// Indicates the maximum number of connections to a shared virtual space
        /// 
        /// If you are using this property, please join the discussion at proposal [#226](https://github.com/openactive/modelling-opportunity-data/issues/226).
        /// </summary>
        [DataMember(Name = "beta:maximumVirtualAttendeeCapacity", EmitDefaultValue = false, Order = 1010)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual long? MaximumVirtualAttendeeCapacity { get; set; }

    }
}
