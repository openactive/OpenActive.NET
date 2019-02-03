
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [PropertyValue](https://schema.org/PropertyValue), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class PropertyValue : Schema.NET.PropertyValue
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "PropertyValue";

        
        /// <summary>
        /// The name of this PropertyValue
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Vendor ID"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A commonly used identifier for the characteristic represented by the property
        /// </summary>
        /// <example>
        /// <code>
        /// "propertyID": "ActivePlaces"
        /// </code>
        /// </example>
        [DataMember(Name = "propertyID", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<string, Uri> PropertyID { get; set; }


        /// <summary>
        /// The actual value of this identifier
        /// </summary>
        /// <example>
        /// <code>
        /// "value": "SB1234"
        /// </code>
        /// </example>
        [DataMember(Name = "value", Order = 115)]
        [JsonConverter(typeof(Schema.NET.ValuesConverter))]
        public new virtual Schema.NET.Values<int?, string> Value { get; set; }

    }
}
