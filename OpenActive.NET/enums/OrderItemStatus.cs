using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  OrderItemStatus
    {
        [EnumMember(Value = "https://openactive.io/SellerCancelled")]
        SellerCancelled,
        [EnumMember(Value = "https://openactive.io/CustomerCancelled")]
        CustomerCancelled,
        [EnumMember(Value = "https://openactive.io/OrderItemProposed")]
        OrderItemProposed,
        [EnumMember(Value = "https://openactive.io/OrderItemConfirmed")]
        OrderItemConfirmed,
        [EnumMember(Value = "https://openactive.io/CustomerAttended")]
        CustomerAttended
    }
}
