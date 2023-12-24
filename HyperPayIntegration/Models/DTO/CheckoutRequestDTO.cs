

using System.Text.Json.Serialization;

namespace HyperPayIntegration.Models.DTO
{
    public class CheckoutRequestDTO
    {
        [JsonIgnore]
        public string EntityId { get; init; } = "8a8294174b7ecb28014b9699220015ca";
        public decimal Amount { get; init; }
        public string Currency { get; init; }
        public string PaymentType { get; init; }
    }
}
