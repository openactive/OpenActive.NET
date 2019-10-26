
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [PriceSpecification](https://schema.org/PriceSpecification), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class TaxChargeSpecification : PriceSpecification
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "TaxChargeSpecification";

        
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
        /// The name of the tax charge, e.g. "VAT at 0% for EU transactions"
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 8)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The total amount.
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false, Order = 9)]
        public new virtual decimal? Price { get; set; }


        /// <summary>
        /// The currency of the price. Specified as a 3-letter ISO 4217 value. If a  PriceSpecification has a zero price, then this property is not required. Otherwise the priceCurrency must be specified.
        /// </summary>
        [DataMember(Name = "priceCurrency", EmitDefaultValue = false, Order = 10)]
        public new virtual string PriceCurrency { get; set; }


        /// <summary>
        /// The rate of VAT.
        /// </summary>
        [DataMember(Name = "rate", EmitDefaultValue = false, Order = 11)]
        public virtual decimal? Rate { get; set; }

    }
}
