using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// </summary>
    public enum  PaymentMethod
    {
        [EnumMember(Value = "http://purl.org/goodrelations/v1#Cash")]
        Cash,
        [EnumMember(Value = "http://purl.org/goodrelations/v1#PaymentMethodCreditCard")]
        PaymentMethodCreditCard
    }
}
