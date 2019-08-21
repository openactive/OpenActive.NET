
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Thing](https://schema.org/Thing), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class OpenBookingError : Schema.NET.Thing
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "OpenBookingError";

        
        /// <summary>
        /// A short, human-readable summary of the problem type. It should not change from occurrence to occurrence of the problem, except for purposes of localization.
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "No customer details supplied"
        /// </code>
        /// </example>
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 7)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A slightly longer, human-readable summary of the problem type. It largely should not change from occurrence to occurrence of the problem, except for purposes of localization or to provide specific information about why the error occurred in that particular case.
        /// </summary>
        /// <example>
        /// <code>
        /// "description": "No customer details supplied. These must be supplied for calls to C2, P, and B."
        /// </code>
        /// </example>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 8)]
        public new virtual string Description { get; set; }

    }
}
