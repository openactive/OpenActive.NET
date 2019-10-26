
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
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "IndividualFacilityUse";

        
        /// <summary>
        /// Inverse of the oa:individualFacilityUse property. Relates an oa:IndividualFacilityUse (e.g. an opportunity to play tennis on a specific court) to a oa:FacilityUse (e.g. an opportunity to play tennis at a specific location).
        /// </summary>
        [DataMember(Name = "aggregateFacilityUse", EmitDefaultValue = false, Order = 7)]
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
        public new virtual List<Slot> Event { get; set; }

    }
}
