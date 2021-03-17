using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class RoleVM
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
