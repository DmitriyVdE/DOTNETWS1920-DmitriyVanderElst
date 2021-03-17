using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class PostDeleteVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("posterId")]
        public string PosterId { get; set; }
        [JsonPropertyName("postername")]
        public string Postername { get; set; }
    }
}
