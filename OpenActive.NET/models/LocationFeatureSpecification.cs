
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [LocationFeatureSpecification](https://schema.org/LocationFeatureSpecification), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class LocationFeatureSpecification : Schema.NET.LocationFeatureSpecification
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "LocationFeatureSpecification";

        
        /// <summary>
        /// A string, suitable for presentation in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Bike Shed"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A boolean value indicating whether this ammenity is available.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual bool? Value { get; set; }

    }
}
