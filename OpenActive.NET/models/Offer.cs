using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// This type is derived from https://schema.org/Offer, which means that any of this type's properties within schema.org may also be used.
    /// </summary>
    [DataContract]
    public partial class Offer : Schema.NET.Offer
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
        public override string Type => "Offer";

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
        /// The name of the Offer suitable for communication to participants.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Speedball winger position"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }

        /// <summary>
        /// A plain text description of the Offer, which must not include HTML or other markup.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Concession requirements are available at https://www.fusion-lifestyle.com/. Proof of entitlement to concession membership must be provided when you visit the centre."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }

        /// <summary>
        /// Indicates the offline payment methods accepted by this provider.
        /// </summary>
        /// <example>
        /// <code>
        /// "acceptedPaymentMethod": [
        ///   "http://purl.org/goodrelations/v1#Cash",
        ///   "http://purl.org/goodrelations/v1#PaymentMethodCreditCard"
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "acceptedPaymentMethod", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual List<PaymentMethod> AcceptedPaymentMethod { get; set; }

        /// <summary>
        /// [DEPRECATED: Use `ageRestriction` instead of `ageRange` within the `Offer` for cases where the `Offer` is age restricted.]
        /// Indicates that an Offer is only applicable to a specific age range.
        /// </summary>
        [DataMember(Name = "ageRange", EmitDefaultValue = false, Order = 11)]
        [JsonConverter(typeof(ValuesConverter))]
        [Obsolete("Use `ageRestriction` instead of `ageRange` within the `Offer` for cases where the `Offer` is age restricted.", false)]
        public virtual QuantitativeValue AgeRange { get; set; }

        /// <summary>
        /// Indicates that an Offer can only be purchased by participants within a specific age range. Specified as a QuantitativeValue with minValue and maxValue properties. This must be displayed prominently to the user when selecting an `Offer` or before booking.
        /// </summary>
        /// <example>
        /// <code>
        /// "ageRestriction": {
        ///   "@type": "QuantitativeValue",
        ///   "minValue": 15,
        ///   "maxValue": 60
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "ageRestriction", EmitDefaultValue = false, Order = 12)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue AgeRestriction { get; set; }

        /// <summary>
        /// Whether the opportunity can be cancelled with a full refund at any time before the `startDate`, or before the `latestCancellationBeforeStartDate` if provided.
        /// </summary>
        [DataMember(Name = "allowCustomerCancellationFullRefund", EmitDefaultValue = false, Order = 13)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual bool? AllowCustomerCancellationFullRefund { get; set; }

        /// <summary>
        /// Offers in open data can be marked as requiring an entitlement type via `eligibleEntitlementType`. The same Offer may be applicable to multiple entitlement types, and the Customer must have at least one matching entitlement type to qualify for the Offer.
        /// Note that this property is in EARLY RELEASE AND IS SUBJECT TO CHANGE, as the [Customer Accounts proposal](https://github.com/openactive/customer-accounts) evolves.
        /// </summary>
        /// <example>
        /// <code>
        /// "eligibleEntitlementType": [
        ///   {
        ///     "@type": "Concept",
        ///     "@id": "https://data.mcractive.com/openactive/entitlement-list#5e78bcbe-36db-425a-9064-bf96d09cc351",
        ///     "prefLabel": "MCRactive Adult Resident",
        ///     "inScheme": "https://data.mcractive.com/openactive/entitlement-list"
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "eligibleEntitlementType", EmitDefaultValue = false, Order = 14)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Concept> EligibleEntitlementType { get; set; }

        /// <summary>
        /// The duration before the startDate during which this Offer may not be cancelled, given in ISO 8601 format.
        /// </summary>
        [DataMember(Name = "latestCancellationBeforeStartDate", EmitDefaultValue = false, Order = 15)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? LatestCancellationBeforeStartDate { get; set; }

        /// <summary>
        /// Can include  https://openactive.io/OpenBookingIntakeForm,  https://openactive.io/OpenBookingAttendeeDetails,  https://openactive.io/OpenBookingApproval,  https://openactive.io/OpenBookingNegotiation,  https://openactive.io/OpenBookingMessageExchange
        /// </summary>
        [DataMember(Name = "openBookingFlowRequirement", EmitDefaultValue = false, Order = 16)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<OpenBookingFlowRequirement> OpenBookingFlowRequirement { get; set; }

        /// <summary>
        /// Indicates whether to accept this offer, a participant must book in advance, whether they must pay on attending, or have option to do either. Values must be one of  https://openactive.io/Required,  https://openactive.io/Optional or  https://openactive.io/Unavailable.
        /// </summary>
        /// <example>
        /// <code>
        /// "openBookingInAdvance": "https://openactive.io/Required"
        /// </code>
        /// </example>
        [DataMember(Name = "openBookingInAdvance", EmitDefaultValue = false, Order = 17)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual RequiredStatusType? OpenBookingInAdvance { get; set; }

        /// <summary>
        /// Indicates whether to accept this offer, a participant must pay in advance, pay when attending, or have the option to do either. Values must be one of  https://openactive.io/Required,  https://openactive.io/Optional or  https://openactive.io/Unavailable.
        /// </summary>
        /// <example>
        /// <code>
        /// "openBookingPrepayment": "https://openactive.io/Required"
        /// </code>
        /// </example>
        [DataMember(Name = "openBookingPrepayment", EmitDefaultValue = false, Order = 18)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual RequiredStatusType? OpenBookingPrepayment { get; set; }

        /// <summary>
        /// The offer price of the activity.
        /// This price should be specified without currency symbols and as a floating point number with two decimal places.
        /// The currency of the price should be expressed in the priceCurrency field.
        /// Includes or excludes tax depending on the taxMode of the seller.
        /// </summary>
        /// <example>
        /// <code>
        /// "price": 33
        /// </code>
        /// </example>
        [DataMember(Name = "price", EmitDefaultValue = false, Order = 19)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual decimal? Price { get; set; }

        /// <summary>
        /// The currency of the price. Specified as a 3-letter ISO 4217 value. If an Offer has a zero price, then this property is not required. Otherwise the priceCurrency must be specified.
        /// </summary>
        /// <example>
        /// <code>
        /// "priceCurrency": "GBP"
        /// </code>
        /// </example>
        [DataMember(Name = "priceCurrency", EmitDefaultValue = false, Order = 20)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string PriceCurrency { get; set; }

        /// <summary>
        /// URL describing the offer
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.rphs.org.uk/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 21)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

        /// <summary>
        /// The duration before the `startDate` for which this `Offer` is valid, given in ISO 8601 format. This is a relatively-defined equivalent of `schema:validFrom`, to allow for `Offer` inheritance.
        /// </summary>
        [DataMember(Name = "validFromBeforeStartDate", EmitDefaultValue = false, Order = 22)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? ValidFromBeforeStartDate { get; set; }

        /// <summary>
        /// The duration before the `startDate` after which the `Offer` is no longer valid, given in ISO 8601 format. This is a relatively-defined equivalent of `schema:validThrough`, to allow for `Offer` inheritance.
        /// </summary>
        [DataMember(Name = "validThroughBeforeStartDate", EmitDefaultValue = false, Order = 23)]
        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]
        public virtual TimeSpan? ValidThroughBeforeStartDate { get; set; }

        /// <summary>
        /// [NOTICE: This is a beta property, and is highly likely to change in future versions of this library.]
        /// Number of people the reservation should accommodate.
        /// 
        /// If you are using this property, please join the discussion at proposal [#250](https://github.com/openactive/modelling-opportunity-data/issues/250).
        /// </summary>
        [DataMember(Name = "beta:partySize", EmitDefaultValue = false, Order = 1024)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual QuantitativeValue PartySize { get; set; }
    }
}
