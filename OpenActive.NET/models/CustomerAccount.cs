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
    /// This type is derived from https://schema.org/Thing, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class CustomerAccount : Schema.NET.Thing
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
        public override string Type => "CustomerAccount";

        /// <summary>
        /// The identifier of the Customer Account used by the Booking System.
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "fdc14503-275e-46d3-9922-45b986c9f9aa"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Identifier { get; set; }

        /// <summary>
        /// The barcode, QR code, magnetic stripe, or swipe card associated with this Customer Account, within their own namespaces.
        /// </summary>
        [DataMember(Name = "accessPass", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Barcode> AccessPass { get; set; }

        /// <summary>
        /// The customer-facing identifier for the Customer Account.
        /// </summary>
        [DataMember(Name = "accountNumber", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string AccountNumber { get; set; }

        /// <summary>
        /// The person or organization to whom this Customer Account belongs.
        /// </summary>
        [DataMember(Name = "customer", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ILegalEntity Customer { get; set; }

        /// <summary>
        /// The current valid and active entitlements associated with this customer. Note that expired or inactive entitlements are not included in this list.
        /// </summary>
        [DataMember(Name = "entitlement", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Entitlement> Entitlement { get; set; }

        /// <summary>
        /// Whether there are any additional entitlements (other than those listed in entitlement) or other types of discounts are associated with the Customer Account that will influence pricing, and therefore whether the pricing for the entitlement in the feed should be treated as indicative.
        /// </summary>
        /// <example>
        /// <code>
        /// "hasHiddenEntitlements": "true"
        /// </code>
        /// </example>
        [DataMember(Name = "hasHiddenEntitlements", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? HasHiddenEntitlements { get; set; }

        /// <summary>
        /// Outstanding actions on this Customer Account, such as the resolution of outstanding debts or membership renewal. These may prevent the Customer from making bookings.
        /// </summary>
        [DataMember(Name = "outstandingAction", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Action> OutstandingAction { get; set; }
    }
}
