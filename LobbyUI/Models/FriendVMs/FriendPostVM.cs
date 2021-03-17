using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class FriendPostVM
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("userId2")]
        public string UserId2 { get; set; }
    }
}
