using System;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class PostVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("postedBy")]
        public UserVM PostedBy { get; set; }

        [JsonPropertyName("postType")]
        public string PostType { get; set; }

        [JsonPropertyName("userWall")]
#nullable enable
        public UserVM? UserWall { get; set; }
        [JsonPropertyName("groupWall")]
#nullable enable
        public GroupVM? GroupWall { get; set; }

        [JsonPropertyName("postedOn")]
        public DateTime PostedOn { get; set; }
    }
}
