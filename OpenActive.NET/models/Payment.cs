
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Thing](https://schema.org/Thing), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class Payment : Schema.NET.Thing
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Payment";

        
        /// <summary>
        /// The identifier of the payment held by the Broker and/or Payment Provider.
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<long?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// Optional free text description of the payment method for the Booking System, to help the Seller in discussions with the Customer (e.g. 'AcmeBroker Points' or 'AcmeBroker via Credit Card').
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A reference used by the Seller to group transactions, which is used to aid reconciliation.
        /// </summary>
        [DataMember(Name = "accountId", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string AccountId { get; set; }


        /// <summary>
        /// paymentMethod must not be used, and is reserved for future versions of this specification.
        /// </summary>
        [DataMember(Name = "paymentMethod", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual PaymentMethod? PaymentMethod { get; set; }


        /// <summary>
        /// A reference to the specific Payment Provider that is used.
        /// </summary>
        [DataMember(Name = "paymentProviderId", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string PaymentProviderId { get; set; }

    }
}
