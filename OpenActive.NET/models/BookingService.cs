
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
        public new virtual string Name { get; set; }


        /// <summary>
        /// The terms of service of the Booking System.
        /// </summary>
        [DataMember(Name = "termsOfService", EmitDefaultValue = false, Order = 8)]
        public new virtual List<Terms> TermsOfService { get; set; }


        /// <summary>
        /// The URL of the website of the Booking System.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 9)]
        public new virtual Uri Url { get; set; }

    }
}
