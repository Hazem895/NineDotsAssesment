using System.Text.Json.Serialization;

namespace NineDotsAssesment.Shared.Models
{
    public class MobileOTPServiceResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("quotaRemaining")]
        public int QuotaRemaining { get; set; }

        [JsonPropertyName("textId")]
        public int TextId { get; set; }
    }
}
