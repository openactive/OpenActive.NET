
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Offer](https://schema.org/Offer), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Offer : Schema.NET.Offer
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Offer";

        
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
        [DataMember(Name = "acceptedPaymentMethod", Order = 115)]
        public new virtual List<PaymentMethod?> AcceptedPaymentMethod { get; set; }


        /// <summary>
        /// Indicates whether to accept this offer, a participant must book in advance, whether they must pay on attending, or have option to do either.
        /// </summary>
        /// <example>
        /// <code>
        /// "advanceBooking": "https://openactive.io/Required"
        /// </code>
        /// </example>
        [DataMember(Name = "advanceBooking", Order = 115)]
        public virtual RequiredStatusType? AdvanceBooking { get; set; }


        /// <summary>
        /// Indicates that an event is suitable for a specific age range. If only a single age is specified then this is assumed to be a minimum age. Age ranges can be specified as follows: 18-30
        /// </summary>
        /// <example>
        /// <code>
        /// "ageRange": {
        ///   "type": "QuantitativeValue",
        ///   "minValue": 15,
        ///   "maxValue": 60
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "ageRange", Order = 115)]
        public virtual QuantitativeValue AgeRange { get; set; }


        /// <summary>
        /// A free text description of the Offer
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "Concession requirements are available at https://www.fusion-lifestyle.com/. Proof of entitlement to concession membership must be provided when you visit the centre."
        /// </code>
        /// </example>
        [DataMember(Name = "description", Order = 115)]
        public new virtual string Description { get; set; }


        /// <summary>
        /// A local non-URI identifier for the resource
        /// </summary>
        /// <example>
        /// <code>
        /// "identifier": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "identifier", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<int?, string, PropertyValue, List<PropertyValue>> Identifier { get; set; }


        /// <summary>
        /// A human readable name for the offer.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Speedball winger position"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// Indicates whether to accept this offer, a participant must pay in advance, pay when attending, or have the option to do either.
        /// </summary>
        /// <example>
        /// <code>
        /// "prepayment": "https://openactive.io/Required"
        /// </code>
        /// </example>
        [DataMember(Name = "prepayment", Order = 115)]
        public virtual RequiredStatusType? Prepayment { get; set; }


        /// <summary>
        /// The offer price of the activity. 
        /// This price should be specified without currency symbols and as a floating point number with two decimal places. 
        /// The currency of the price should be expressed in the priceCurrency field.
        /// </summary>
        /// <example>
        /// <code>
        /// "price": 33
        /// </code>
        /// </example>
        [DataMember(Name = "price", Order = 115)]
        public new virtual decimal? Price { get; set; }


        /// <summary>
        /// The currency (in 3-letter ISO 4217 format) of the price. 
        /// If an Offer has a zero price, then this property is not required. Otherwise the currency must be specified.
        /// </summary>
        /// <example>
        /// <code>
        /// "priceCurrency": "GBP"
        /// </code>
        /// </example>
        [DataMember(Name = "priceCurrency", Order = 115)]
        public new virtual string PriceCurrency { get; set; }


        /// <summary>
        /// URL describing the offer
        /// </summary>
        /// <example>
        /// <code>
        /// "url": "http://www.rphs.org.uk/"
        /// </code>
        /// </example>
        [DataMember(Name = "url", Order = 115)]
        public new virtual Uri Url { get; set; }


        /// <summary>
        /// [NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] 
        /// The channels through which a booking can be made.
        /// 
        /// If you are using this property, please join the discussion at proposal [#161](https://github.com/openactive/modelling-opportunity-data/issues/161).
        /// </summary>
        [DataMember(Name = "beta:availableChannel", Order = 115)]
        public virtual List<AvailableChannelType?> AvailableChannel { get; set; }

    }
}
