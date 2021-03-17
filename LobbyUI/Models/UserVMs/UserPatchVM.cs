using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserPatchVM
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("currentPassword")]
        [Required]
        public string CurrentPassword { get; set; }

        [JsonPropertyName("newPassword")]
        [Required]
        public string NewPassword { get; set; }
    }
}