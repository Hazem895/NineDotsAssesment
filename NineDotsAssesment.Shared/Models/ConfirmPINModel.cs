using System.Text.Json.Serialization;

namespace NineDotsAssesment.Shared.Models
{
    public class ConfirmPINModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("pin")]
        public string PIN { get; set; }
        [JsonPropertyName("confirmed_pin")]
        public string ConfirmedPIN { get; set; }
    }
}
