using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  OrderCreationStatus
    {
        [EnumMember(Value = "https://openactive.io/OrderCreationPaymentAuthorized")]
        OrderCreationPaymentAuthorized,
        [EnumMember(Value = "https://openactive.io/OrderCreationPaymentCaptured")]
        OrderCreationPaymentCaptured,
        [EnumMember(Value = "https://openactive.io/OrderCreationComplete")]
        OrderCreationComplete,
        [EnumMember(Value = "https://openactive.io/OrderCreationPaymentDue")]
        OrderCreationPaymentDue
    }
}
