using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserDeleteVM
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("userName")]
        [Required]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
    }
}
