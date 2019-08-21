
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// 
    /// This type is derived from [Order](https://schema.org/Order), which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available.
    /// </summary>
    [DataContract]
    public partial class OrderQuote : Order
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "OrderQuote";

        
        /// <summary>
        /// The Lease on the OrderItems which lasts for the duration specified by the Booking System.
        /// </summary>
        [DataMember(Name = "lease", EmitDefaultValue = false, Order = 7)]
        public virtual Lease Lease { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Uri OrderProposalVersion { get; set; }


        /// <summary>
        /// Whether the Booking Flow with Approval must be used to book the set of OrderItems included. must be true if any of the OrderItems require approval.
        /// </summary>
        [DataMember(Name = "orderRequiresApproval", EmitDefaultValue = false, Order = 9)]
        public virtual bool? OrderRequiresApproval { get; set; }


        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override Payment Payment { get; set; }

    }
}
