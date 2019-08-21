
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    [DataContract]
    public partial class PriceSpecification : Schema.NET.PriceSpecification
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "PriceSpecification";

        
        /// <summary>
        /// The total amount.
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false, Order = 7)]
        public new virtual decimal? Price { get; set; }


        /// <summary>
        /// The currency of the price. Specified as a 3-letter ISO 4217 value. If a  PriceSpecification has a zero price, then this property is not required. Otherwise the priceCurrency must be specified.
        /// </summary>
        [DataMember(Name = "priceCurrency", EmitDefaultValue = false, Order = 8)]
        public new virtual string PriceCurrency { get; set; }

    }
}
