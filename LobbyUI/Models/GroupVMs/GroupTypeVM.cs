using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupTypeVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
