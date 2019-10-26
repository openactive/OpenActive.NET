
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [DigitalDocument](https://schema.org/DigitalDocument), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class Terms : Schema.NET.DigitalDocument
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Terms";

        
        /// <summary>
        /// The name of the terms. The name must distinguish this from other terms fields provided, e.g. 'Terms and Conditions' or 'Privacy Policy'.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "requiresExplicitConsent", EmitDefaultValue = false, Order = 8)]
        public virtual bool? RequiresExplicitConsent { get; set; }


        /// <summary>
        /// The URL of the webpage containing the contents of the terms.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false, Order = 9)]
        public new virtual Uri Url { get; set; }

    }
}
