
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [PostalAddress](https://schema.org/PostalAddress), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class PostalAddress : Schema.NET.PostalAddress
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "PostalAddress";

        
        /// <summary>
        /// The country, expressed as a two-letter ISO 3166-1 alpha-2 country code.
        /// </summary>
        /// <example>
        /// <code>
        /// "addressCountry": "GB"
        /// </code>
        /// </example>
        [DataMember(Name = "addressCountry", EmitDefaultValue = false, Order = 7)]
        public new virtual string AddressCountry { get; set; }


        /// <summary>
        /// The locality, a suburb within a city or a town within a county or district.
        /// </summary>
        /// <example>
        /// <code>
        /// "addressLocality": "Shoreditch"
        /// </code>
        /// </example>
        [DataMember(Name = "addressLocality", EmitDefaultValue = false, Order = 8)]
        public new virtual string AddressLocality { get; set; }


        /// <summary>
        /// The region, either a city or a county or district.
        /// </summary>
        /// <example>
        /// <code>
        /// "addressRegion": "London"
        /// </code>
        /// </example>
        [DataMember(Name = "addressRegion", EmitDefaultValue = false, Order = 9)]
        public new virtual string AddressRegion { get; set; }


        /// <summary>
        /// The postal code.
        /// </summary>
        /// <example>
        /// <code>
        /// "postalCode": "EC2A 4JE"
        /// </code>
        /// </example>
        [DataMember(Name = "postalCode", EmitDefaultValue = false, Order = 10)]
        public new virtual string PostalCode { get; set; }


        /// <summary>
        /// The street address.
        /// </summary>
        /// <example>
        /// <code>
        /// "streetAddress": "Open Data Institute, Floor 3, 65 Clifton St"
        /// </code>
        /// </example>
        [DataMember(Name = "streetAddress", EmitDefaultValue = false, Order = 11)]
        public new virtual string StreetAddress { get; set; }

    }
}
