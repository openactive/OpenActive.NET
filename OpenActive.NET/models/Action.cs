
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Action](https://schema.org/Action), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public class Action : Schema.NET.Action
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "Action";

        
        /// <summary>
        /// The name of the action
        /// </summary>
        /// <example>
        /// <code>
        /// "name": "Book"
        /// </code>
        /// </example>
        [DataMember(Name = "name", Order = 115)]
        public new virtual string Name { get; set; }


        /// <summary>
        /// A definition of the target of the action.
        /// </summary>
        /// <example>
        /// <code>
        /// "target": {
        ///   "encodingType": "application/vnd.openactive.v1.0+json",
        ///   "httpMethod": "POST",
        ///   "type": "EntryPoint",
        ///   "url": "https://example.com/orders"
        /// }
        /// </code>
        /// </example>
        [DataMember(Name = "target", Order = 115)]
        public new virtual EntryPoint Target { get; set; }

    }
}
