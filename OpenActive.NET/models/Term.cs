
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
    public partial class Term : Schema.NET.DigitalDocument
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Term";

        
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
