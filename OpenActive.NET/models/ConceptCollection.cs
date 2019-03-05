
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// [NOTICE: This is a beta class, and is highly likely to change in future versions of this library.]. 
    /// 
    /// </summary>
    [DataContract]
    public partial class ConceptCollection : Schema.NET.CreativeWork
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "beta:ConceptCollection";

        
    }
}
