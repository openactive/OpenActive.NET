
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [GeoCoordinates](https://schema.org/GeoCoordinates), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class GeoCoordinates : Schema.NET.GeoCoordinates
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "GeoCoordinates";

        
        /// <summary>
        /// The latitude of a location. For example 51.522338 (WGS 84).
        /// </summary>
        /// <example>
        /// <code>
        /// "latitude": 51.522338
        /// </code>
        /// </example>
        [DataMember(Name = "latitude", EmitDefaultValue = false, Order = 7)]
        public new virtual decimal? Latitude { get; set; }


        /// <summary>
        /// The longitude of a location. For example -0.083437 (WGS 84).
        /// </summary>
        /// <example>
        /// <code>
        /// "longitude": -0.083437
        /// </code>
        /// </example>
        [DataMember(Name = "longitude", EmitDefaultValue = false, Order = 8)]
        public new virtual decimal? Longitude { get; set; }

    }
}
