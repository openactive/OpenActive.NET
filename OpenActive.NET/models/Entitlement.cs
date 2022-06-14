using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// EARLY RELEASE NOTICE: This class represents a draft that is designed to inform the OpenActive specification work with implementation feedback. IT IS STILL SUBJECT TO CHANGE, as the [Customer Accounts proposal](https://github.com/openactive/customer-accounts) evolves.
    /// 
    /// This type is derived from https://schema.org/Permit, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Entitlement : Schema.NET.Permit
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
        public override string Type => "Entitlement";

        /// <summary>
        /// For the request, this is the value of the `@id` of the Concept being referenced. For the response, this the full Concept object including the `@id` and prefLabel.
        /// </summary>
        /// <example>
        /// <code>
        /// "entitlementType": {
        ///   "@type": "Concept",
        ///   "@id": "https://data.mcractive.com/openactive/entitlement-list#5e78bcbe-36db-425a-9064-bf96d09cc351",
        ///   "prefLabel": "MCRactive Adult Resident",
        ///   "inScheme": "https://data.mcractive.com/openactive/entitlement-list"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "entitlementType", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual ReferenceValue<Concept> EntitlementType { get; set; }

        /// <summary>
        /// Any evidence request associated with the entitlement.
        /// </summary>
        [DataMember(Name = "evidenceRequestAction", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Action EvidenceRequestAction { get; set; }

        /// <summary>
        /// The date the entitlement becomes valid. This must be in the past.
        /// </summary>
        [DataMember(Name = "validFrom", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public new virtual DateValue ValidFrom { get; set; }

        /// <summary>
        /// The date that the entitlement is no longer valid. This must be in the future.
        /// </summary>
        [DataMember(Name = "validUntil", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(OpenActiveDateTimeValuesConverter))]
        public new virtual DateValue ValidUntil { get; set; }
    }
}
