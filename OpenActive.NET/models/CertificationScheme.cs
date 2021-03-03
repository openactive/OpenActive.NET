
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This is a beta class, and is highly likely to change in future versions of this library.] 
    /// This type is derived from https://schema.org/Thing, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class CertificationScheme : Schema.NET.Thing
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
        public override string Type => "beta:CertificationScheme";


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Property containing an array of CertificationLevels
        /// 
        /// If you are using this property, please join the discussion at proposal [#217](https://github.com/openactive/modelling-opportunity-data/issues/217).
        /// </summary>
        [DataMember(Name = "beta:certificationLevel", EmitDefaultValue = false, Order = 1006)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual CertificationLevel CertificationLevel { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// From within a CertificationScheme, points to other CertificationSchemes considered valid and trusted in order to allow the creation of a trust network.
        /// 
        /// If you are using this property, please join the discussion at proposal [#217](https://github.com/openactive/modelling-opportunity-data/issues/217).
        /// </summary>
        [DataMember(Name = "beta:trustedCertificationSchemes", EmitDefaultValue = false, Order = 1007)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri TrustedCertificationSchemes { get; set; }

    }
}
