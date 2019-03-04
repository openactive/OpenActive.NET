
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [QuantitativeValue](https://schema.org/QuantitativeValue), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class QuantitativeValue : Schema.NET.QuantitativeValue
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "QuantitativeValue";

        
        /// <summary>
        /// The maximum value.
        /// </summary>
        /// <example>
        /// <code>
        /// "maxValue": 60
        /// </code>
        /// </example>
        [DataMember(Name = "maxValue", EmitDefaultValue = false, Order = 7)]
        public new virtual int? MaxValue { get; set; }


        /// <summary>
        /// The minimum value.
        /// </summary>
        /// <example>
        /// <code>
        /// "minValue": 16
        /// </code>
        /// </example>
        [DataMember(Name = "minValue", EmitDefaultValue = false, Order = 8)]
        public new virtual int? MinValue { get; set; }

    }
}
