
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
    public partial class OrderProposal : OrderQuote
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "OrderProposal";

        
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "orderCustomerNote", EmitDefaultValue = false, Order = 7)]
        public virtual string OrderCustomerNote { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "orderProposalStatus", EmitDefaultValue = false, Order = 8)]
        public virtual OrderProposalStatus? OrderProposalStatus { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "orderSellerNote", EmitDefaultValue = false, Order = 9)]
        public virtual string OrderSellerNote { get; set; }

    }
}
