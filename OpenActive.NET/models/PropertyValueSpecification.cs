
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [PropertyValueSpecification](https://schema.org/PropertyValueSpecification), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class PropertyValueSpecification : Schema.NET.PropertyValueSpecification
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "PropertyValueSpecification";

        
        /// <summary>
        /// Display label for the field.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// Descriptive help text for the field.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Description { get; set; }


        /// <summary>
        /// Specifies that a value for the field is required to proceed with the booking.
        /// </summary>
        [DataMember(Name = "valueRequired", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string ValueRequired { get; set; }

    }
}
