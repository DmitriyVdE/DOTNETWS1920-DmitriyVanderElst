using System;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class PostPostVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("postTypeId")]
        public int PostTypeId { get; set; }

        [JsonPropertyName("userWallId")]
#nullable enable
        public string? UserWallId { get; set; }
        [JsonPropertyName("groupWallId")]
#nullable enable
        public int? GroupWallId { get; set; }

        [JsonPropertyName("postedOn")]
        public DateTime PostedOn { get; set; }
    }
}
