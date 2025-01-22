using System.Text.Json.Serialization;

namespace CarRegistration.Server.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Registration { get; set; }

        [JsonPropertyName("registrationExpiry")]
        public DateTime RegistrationExpiry { get; set; }
    }
}
