using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserVM
    {
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; }

        [JsonPropertyName("userName")]
        [Required]
        public string UserName { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("roles")]
        public ICollection<RoleVM> Roles { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}