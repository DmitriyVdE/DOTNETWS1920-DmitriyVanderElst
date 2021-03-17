using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class RoleDetailsVM
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("users")]
        public ICollection<UserVM> Users { get; set; }
    }
}
