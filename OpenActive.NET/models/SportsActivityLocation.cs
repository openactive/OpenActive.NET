
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [SportsActivityLocation](https://schema.org/SportsActivityLocation), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class SportsActivityLocation : Schema.NET.SportsActivityLocation
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "SportsActivityLocation";

        
        /// <summary>
        /// While a `url` is not specified as an option in the Modelling Specification, it is necessary to link entities in RPDE.
        /// </summary>
        /// <example>
        /// <code>
        /// "containedInPlace": "http://www.example.org/api/locations/8958f9b8-2004-4e90-80ff-50c98a9b121d"
        /// </code>
        /// </example>
        [DataMember(Name = "containedInPlace", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual SingleValues<Uri, Place> ContainedInPlace { get; set; }

    }
}
