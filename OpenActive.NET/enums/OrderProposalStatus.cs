using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  OrderProposalStatus
    {
        [EnumMember(Value = "https://openactive.io/AwaitingSellerConfirmation")]
        AwaitingSellerConfirmation,
        [EnumMember(Value = "https://openactive.io/SellerAccepted")]
        SellerAccepted,
        [EnumMember(Value = "https://openactive.io/SellerRejected")]
        SellerRejected,
        [EnumMember(Value = "https://openactive.io/CustomerRejected")]
        CustomerRejected
    }
}
