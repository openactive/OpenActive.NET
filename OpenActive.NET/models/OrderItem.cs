
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [OrderItem](https://schema.org/OrderItem), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class OrderItem : Schema.NET.OrderItem
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "OrderItem";

        
        /// <summary>
        /// The offer from the associated orderedItem that has been selected by the Customer. The price of this includes or excludes tax depending on the taxMode of the Order.
        /// </summary>
        [DataMember(Name = "acceptedOffer", EmitDefaultValue = false, Order = 7)]
        public new virtual Offer AcceptedOffer { get; set; }


        /// <summary>
        /// PropertyValue that contains a text value usable for entrance. Not applicable for an  OrderQuote.
        /// </summary>
        [DataMember(Name = "accessCode", EmitDefaultValue = false, Order = 8)]
        public new virtual List<PropertyValue> AccessCode { get; set; }


        /// <summary>
        /// ImageObject or Barcode that contains reference to an asset (e.g. Barcode, QR code image or PDF) usable for entrance. Not applicable for an OrderQuote.
        /// </summary>
        [DataMember(Name = "accessToken", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<BarCode, ImageObject> AccessToken { get; set; }


        /// <summary>
        /// PropertyValue that contains a text value useful for reconciliation.
        /// </summary>
        [DataMember(Name = "additionalProperty", EmitDefaultValue = false, Order = 10)]
        public new virtual List<PropertyValue> AdditionalProperty { get; set; }


        /// <summary>
        /// Whether the event can be cancelled.
        /// </summary>
        [DataMember(Name = "allowCustomerCancellationFullRefund", EmitDefaultValue = false, Order = 11)]
        public virtual bool? AllowCustomerCancellationFullRefund { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "attendee", EmitDefaultValue = false, Order = 12)]
        public new virtual Person Attendee { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "attendeeDetailsRequired", EmitDefaultValue = false, Order = 13)]
        public virtual List<Uri> AttendeeDetailsRequired { get; set; }


        /// <summary>
        /// A message set by the Seller in the event of Opportunity cancellation, only applicable for an  Order and where the OrderItem has  orderItemStatus set to  https://openactive.io/SellerCancelled
        /// </summary>
        [DataMember(Name = "cancellationMessage", EmitDefaultValue = false, Order = 14)]
        public virtual string CancellationMessage { get; set; }


        /// <summary>
        /// A message set by the Seller to trigger a notification to the Customer, only applicable for an Order and where the OrderItem has  orderItemStatus set to  https://openactive.io/OrderConfirmed or  https://openactive.io/CustomerAttended
        /// </summary>
        [DataMember(Name = "customerNotice", EmitDefaultValue = false, Order = 15)]
        public virtual string CustomerNotice { get; set; }


        /// <summary>
        /// Array of errors related to the OrderItem being included in the Order, only applicable for an  OrderQuote.
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false, Order = 16)]
        public virtual List<OpenBookingError> Error { get; set; }


        /// <summary>
        /// The specific bookable Thing that has been selected by the Customer. See the [Modelling-Opportunity-Data] for more information on these types. Note that the Broker Request and Orders feed only require id within these objects to be included; in these contexts, all other properties are ignored.
        /// </summary>
        [DataMember(Name = "orderedItem", EmitDefaultValue = false, Order = 17)]
        public new virtual Event OrderedItem { get; set; }


        /// <summary>
        /// PropertyValueSpecifications that describe fields in the orderItemIntakeForm.
        /// </summary>
        [DataMember(Name = "orderItemIntakeForm", EmitDefaultValue = false, Order = 18)]
        public virtual List<PropertyValueSpecification> OrderItemIntakeForm { get; set; }


        /// <summary>
        /// PropertyValues that contains a text value responses to the orderItemIntakeForm.
        /// </summary>
        [DataMember(Name = "orderItemIntakeFormResponse", EmitDefaultValue = false, Order = 19)]
        public virtual List<PropertyValue> OrderItemIntakeFormResponse { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "orderItemStatus", EmitDefaultValue = false, Order = 20)]
        public new virtual List<OrderItemStatus> OrderItemStatus { get; set; }


        /// <summary>
        /// Breakdown of tax payable for the OrderItem.
        /// </summary>
        [DataMember(Name = "unitTaxSpecification", EmitDefaultValue = false, Order = 21)]
        public virtual List<TaxChargeSpecification> UnitTaxSpecification { get; set; }

    }
}
