using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserAuthenticateVM
    {
        [JsonPropertyName("userName")]
        [Required]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
    }
}
