
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Product](https://schema.org/Product), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class IndividualFacilityUse : FacilityUse
    {
        /// <summary>
        /// Returns the JSON-LD representation of this instance.
        /// This method overrides Schema.NET ToString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents the JSON-LD representation of this instance.</returns>
        public override string ToString()
        {
            return OpenActiveSerializer.Serialize(this);
        }

        /// <summary>
        /// Returns the JSON-LD representation of this instance, including "https://schema.org" in the "@context".
        ///
        /// This method must be used when you want to embed the output raw (as-is) into a web
        /// page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
        /// vulnerabilities if the object was constructed from an untrusted source.
        /// 
        /// This method overrides Schema.NET ToHtmlEscapedString() to serialise using OpenActiveSerializer.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents the JSON-LD representation of this instance.
        /// </returns>
        public new string ToHtmlEscapedString()
        {
            return OpenActiveSerializer.SerializeToHtmlEmbeddableString(this);
        }

        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "IndividualFacilityUse";

        
        /// <summary>
        /// Inverse of the oa:individualFacilityUse property. Relates an oa:IndividualFacilityUse (e.g. an opportunity to play tennis on a specific court) to a oa:FacilityUse (e.g. an opportunity to play tennis at a specific location).
        /// </summary>
        [DataMember(Name = "aggregateFacilityUse", EmitDefaultValue = false, Order = 7)]
        [JsonConverter(typeof(ValuesConverter))]
        public virtual FacilityUse AggregateFacilityUse { get; set; }


        /// <summary>
        /// An array of slots of availability of this IndividualFacilityUse.
        /// </summary>
        /// <example>
        /// <code>
        /// "event": [
        ///   {
        ///     "type": "Slot",
        ///     "id": "http://www.example.org/api/individual-facility-uses/432#/event/2018-03-01T10:00:00Z",
        ///     "startDate": "2018-03-01T11:00:00Z",
        ///     "endDate": "2018-03-01T11:30:00Z",
        ///     "duration": "PT30M",
        ///     "remainingUses": 0,
        ///     "maximumUses": 1
        ///   }
        /// ]
        /// </code>
        /// </example>
        [DataMember(Name = "event", EmitDefaultValue = false, Order = 8)]
        [JsonConverter(typeof(ValuesConverter))]
        public override List<Slot> Event { get; set; }

    }
}
