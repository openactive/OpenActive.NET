
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Concept](http://www.w3.org/2004/02/skos/core#Concept).
    /// </summary>
    [DataContract]
    public class Concept 
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public virtual string Type => "Concept";

        
        /// <summary>
        /// An alternative human readable string for use in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "altLabel": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "altLabel", Order = 115)]
        public virtual List<string> AltLabel { get; set; }


        /// <summary>
        /// A broader Concept URI
        /// </summary>
        /// <example>
        /// <code>
        /// "broader": "https://example.com/football"
        /// </code>
        /// </example>
        [DataMember(Name = "broader", Order = 115)]
        public virtual List<Uri> Broader { get; set; }


        /// <summary>
        /// A stable URL reference for the taxonomy.
        /// </summary>
        /// <example>
        /// <code>
        /// "inScheme": "https://example.com/reference/activities"
        /// </code>
        /// </example>
        [DataMember(Name = "inScheme", Order = 115)]
        public virtual Uri InScheme { get; set; }


        /// <summary>
        /// A more specific concept URI
        /// </summary>
        /// <example>
        /// <code>
        /// "narrower": "https://example.com/walking-football"
        /// </code>
        /// </example>
        [DataMember(Name = "narrower", Order = 115)]
        public virtual List<Uri> Narrower { get; set; }


        /// <summary>
        /// A concept label that is not normally recognisable as natural language.
        /// </summary>
        /// <example>
        /// <code>
        /// "notation": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "notation", Order = 115)]
        public virtual string Notation { get; set; }


        /// <summary>
        /// A human readable string for use in user interfaces.
        /// </summary>
        /// <example>
        /// <code>
        /// "prefLabel": "Speedball"
        /// </code>
        /// </example>
        [DataMember(Name = "prefLabel", Order = 115)]
        public virtual string PrefLabel { get; set; }

    }
}
