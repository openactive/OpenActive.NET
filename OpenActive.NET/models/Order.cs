
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Order](https://schema.org/Order), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class Order : Schema.NET.Order
    {
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
        public new virtual SingleValues<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// Details about the Booking System
        /// </summary>
        [DataMember(Name = "bookingService", EmitDefaultValue = false, Order = 8)]
        public virtual BookingService BookingService { get; set; }


        /// <summary>
        /// The organisation or developer providing an application that allows Customers to make bookings. Those applications will be clients of the API defined in this specification. If brokerRole is set to https://openactive/NoBroker this is not required.
        /// </summary>
        [DataMember(Name = "broker", EmitDefaultValue = false, Order = 9)]
        public new virtual Organization Broker { get; set; }


        /// <summary>
        /// Either https://openactive/AgentBroker,  https://openactive/ResellerBroker or  https://openactive/NoBroker, as agreed in advance between the Broker and Seller.
        /// </summary>
        [DataMember(Name = "brokerRole", EmitDefaultValue = false, Order = 10)]
        public virtual BrokerType? BrokerRole { get; set; }


        /// <summary>
        /// The person or organization purchasing the Order.
        /// </summary>
        [DataMember(Name = "customer", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<Organization, Person> Customer { get; set; }


        /// <summary>
        /// This property is internal to the Broker in this version of the specification.
        /// </summary>
        [DataMember(Name = "orderCreationStatus", EmitDefaultValue = false, Order = 12)]
        public virtual OrderCreationStatus? OrderCreationStatus { get; set; }


        /// <summary>
        /// The items that constitute the Order.
        /// </summary>
        [DataMember(Name = "orderedItem", EmitDefaultValue = false, Order = 13)]
        public new virtual List<OrderItem> OrderedItem { get; set; }


        /// <summary>
        /// The Customer-facing identifier of the Order.
        /// </summary>
        [DataMember(Name = "orderNumber", EmitDefaultValue = false, Order = 14)]
        public new virtual string OrderNumber { get; set; }


        /// <summary>
        /// The unique URL representing this version of the  OrderProposal, or the version of the OrderProposal to which this Order is related.
        /// </summary>
        [DataMember(Name = "orderProposalVersion", EmitDefaultValue = false, Order = 15)]
        public virtual Uri OrderProposalVersion { get; set; }


        /// <summary>
        /// The payment associated with the Order by the Broker. It is required for cases where a payment has been taken.
        /// </summary>
        [DataMember(Name = "payment", EmitDefaultValue = false, Order = 16)]
        public virtual Payment Payment { get; set; }


        /// <summary>
        /// The organisation (schema:Organization) providing access to events or facilities via a Booking System. e.g. a leisure provider running yoga classes.
        /// </summary>
        [DataMember(Name = "seller", EmitDefaultValue = false, Order = 17)]
        public new virtual Organization Seller { get; set; }


        /// <summary>
        /// Set to true when business-to-business tax calculation is required by the seller or brokerRole settings, but not supported by the Broker.
        /// </summary>
        [DataMember(Name = "taxCalculationExcluded", EmitDefaultValue = false, Order = 18)]
        public new virtual bool? TaxCalculationExcluded { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "totalPaymentDue", EmitDefaultValue = false, Order = 19)]
        public new virtual PriceSpecification TotalPaymentDue { get; set; }


        /// <summary>
        /// Breakdown of tax payable for the Order.
        /// </summary>
        [DataMember(Name = "totalPaymentTax", EmitDefaultValue = false, Order = 20)]
        public virtual List<TaxChargeSpecification> TotalPaymentTax { get; set; }

    }
}
