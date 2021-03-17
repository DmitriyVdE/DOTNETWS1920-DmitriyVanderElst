using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class PostTypeVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
