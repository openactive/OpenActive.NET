
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Service](https://schema.org/Service), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class BookingService : Schema.NET.Service
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "BookingService";

        
        /// <summary>
        /// The name of the Booking System.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string Name { get; set; }


        /// <summary>
        /// The version of the application, useful for on-premise installations.
        /// </summary>
        [DataMember(Name = "softwareVersion", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual string SoftwareVersion { get; set; }


        /// <summary>
        /// The terms of service of the Booking System.
        /// </summary>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 9)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual List<Terms> TermsOfService { get; set; }


        /// <summary>
        /// The URL of the website of the Booking System.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 10)]
        [JsonConverter(typeof(ValuesConverter))]
        public new virtual Uri Url { get; set; }

    }
}
