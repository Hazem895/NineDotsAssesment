using System.Text.Json.Serialization;

namespace NineDotsAssesment.Shared.Models
{
    public class VerifyOTPRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("otp")]
        public string OTP { get; set; }
    }
}
