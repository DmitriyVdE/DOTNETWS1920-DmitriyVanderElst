using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class PostPutVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
