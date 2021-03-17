using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupUserTypeVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
