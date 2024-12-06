using System.Text.Json.Serialization;

namespace NineDotsAssesment.Shared.Models
{
    public class VerifyOTPResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("isValidOtp")]
        public bool IsValidOtp { get; set; }
    }
}
