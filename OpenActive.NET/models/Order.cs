using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Order, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Order : Schema.NET.Order
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
        public override string Type => "Order";

        /// <summary>
        /// A local non-URI identifier for the resource
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
        /// Details about the Booking System
        /// </summary>
        [DataMember(Name = "bookingService", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual BookingService BookingService { get; set; }

        /// <summary>
        /// The organisation or developer providing an application that allows Customers to make bookings. Those applications will be clients of the API defined in this specification. If brokerRole is set to https://openactive.io/NoBroker this is not required.
        /// </summary>
        [DataMember(Name = "broker", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Organization Broker { get; set; }

        /// <summary>
        /// Either https://openactive.io/AgentBroker,  https://openactive.io/ResellerBroker or  https://openactive.io/NoBroker, as agreed in advance between the Broker and Seller.
        /// </summary>
        [DataMember(Name = "brokerRole", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual BrokerType? BrokerRole { get; set; }

        /// <summary>
        /// The person or organization purchasing the Order.
        /// </summary>
        [DataMember(Name = "customer", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ILegalEntity Customer { get; set; }

        /// <summary>
        /// This property is internal to the Broker in this version of the specification.
        /// </summary>
        [DataMember(Name = "orderCreationStatus", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual OrderCreationStatus? OrderCreationStatus { get; set; }

        /// <summary>
        /// The items that constitute the Order.
        /// </summary>
        [DataMember(Name = "orderedItem", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<OrderItem> OrderedItem { get; set; }

        /// <summary>
        /// The Customer-facing identifier of the Order.
        /// </summary>
        [DataMember(Name = "orderNumber", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string OrderNumber { get; set; }

        /// <summary>
        /// The unique URL representing this version of the  OrderProposal, or the version of the OrderProposal to which this Order is related.
        /// </summary>
        [DataMember(Name = "orderProposalVersion", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Uri OrderProposalVersion { get; set; }

        /// <summary>
        /// The payment associated with the Order by the Broker. It is required for cases where a payment has been taken.
        /// </summary>
        [DataMember(Name = "payment", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual Payment Payment { get; set; }

        /// <summary>
        /// The organisation (schema:Organization) or person (schema:Person) providing access to events or facilities via a Booking System. e.g. a leisure provider or independent instructor running a yoga classes.
        /// </summary>
        [DataMember(Name = "seller", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ILegalEntity Seller { get; set; }

        /// <summary>
        /// Set to true when business-to-business tax calculation is required by the seller or brokerRole settings, but not supported by the Broker.
        /// </summary>
        [DataMember(Name = "taxCalculationExcluded", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? TaxCalculationExcluded { get; set; }

        [DataMember(Name = "totalPaymentDue", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual PriceSpecification TotalPaymentDue { get; set; }

        /// <summary>
        /// Breakdown of tax payable for the Order.
        /// </summary>
        [DataMember(Name = "totalPaymentTax", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<TaxChargeSpecification> TotalPaymentTax { get; set; }
    }
}
