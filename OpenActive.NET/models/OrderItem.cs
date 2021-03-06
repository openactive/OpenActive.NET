using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/OrderItem, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class OrderItem : Schema.NET.OrderItem
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
        public override string Type => "OrderItem";

        /// <summary>
        /// The offer from the associated orderedItem that has been selected by the Customer. The price of this includes or excludes tax depending on the taxMode of the Order.
        /// </summary>
        [DataMember(Name = "acceptedOffer", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ReferenceValue<Offer> AcceptedOffer { get; set; }

        /// <summary>
        /// Channel through which the user can participate in the Opportunity. Not applicable for an OrderQuote.
        /// </summary>
        [DataMember(Name = "accessChannel", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual VirtualLocation AccessChannel { get; set; }

        /// <summary>
        /// PropertyValue that contains a text value usable for entrance. Not applicable for an  OrderQuote.
        /// </summary>
        [DataMember(Name = "accessCode", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<PropertyValue> AccessCode { get; set; }

        /// <summary>
        /// ImageObject or Barcode that contains reference to an asset (e.g. Barcode, QR code image or PDF) usable for entrance. Not applicable for an OrderQuote.
        /// </summary>
        [DataMember(Name = "accessPass", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<ImageObject> AccessPass { get; set; }

        /// <summary>
        /// The person attending the Opportunity related to the OrderItem.
        /// </summary>
        [DataMember(Name = "attendee", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Person Attendee { get; set; }

        /// <summary>
        /// The properties of `schema:Person` that are required to describe an `attendee` for this `OrderItem`.
        /// </summary>
        [DataMember(Name = "attendeeDetailsRequired", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<PropertyEnumeration> AttendeeDetailsRequired { get; set; }

        /// <summary>
        /// A message set by the Seller in the event of Opportunity cancellation, only applicable for an  `Order` and where the `OrderItem` has `orderItemStatus` set to `https://openactive.io/SellerCancelled`
        /// </summary>
        [DataMember(Name = "cancellationMessage", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string CancellationMessage { get; set; }

        /// <summary>
        /// A message set by the Seller to trigger a notification to the Customer, only applicable for an `Order` and where the `OrderItem` has `orderItemStatus` set to  `https://openactive.io/OrderItemConfirmed` or `https://openactive.io/CustomerAttended`
        /// </summary>
        [DataMember(Name = "customerNotice", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual string CustomerNotice { get; set; }

        /// <summary>
        /// Array of errors related to the OrderItem being included in the Order, only applicable for an  OrderQuote.
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<OpenBookingError> Error { get; set; }

        /// <summary>
        /// The specific bookable Thing that has been selected by the Customer. See the [Modelling-Opportunity-Data] for more information on these types. Note that the Broker Request and Orders feed only require id within these objects to be included; in these contexts, all other properties are ignored.
        /// </summary>
        [DataMember(Name = "orderedItem", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual ReferenceValue<Event> OrderedItem { get; set; }

        /// <summary>
        /// PropertyValueSpecifications that describe fields in the orderItemIntakeForm.
        /// </summary>
        [DataMember(Name = "orderItemIntakeForm", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<PropertyValueSpecification> OrderItemIntakeForm { get; set; }

        /// <summary>
        /// PropertyValues that contains a text value responses to the orderItemIntakeForm.
        /// </summary>
        [DataMember(Name = "orderItemIntakeFormResponse", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<PropertyValue> OrderItemIntakeFormResponse { get; set; }

        [DataMember(Name = "orderItemStatus", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual OrderItemStatus? OrderItemStatus { get; set; }

        /// <summary>
        /// An integer representing the order of OrderItems within the array.
        /// </summary>
        [DataMember(Name = "position", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual long? Position { get; set; }

        /// <summary>
        /// Breakdown of tax payable for the OrderItem.
        /// </summary>
        [DataMember(Name = "unitTaxSpecification", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<TaxChargeSpecification> UnitTaxSpecification { get; set; }
    }
}
