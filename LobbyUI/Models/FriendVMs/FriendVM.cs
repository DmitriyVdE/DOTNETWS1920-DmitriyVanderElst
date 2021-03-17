using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class FriendVM
    {
        [JsonPropertyName("id")]
        public string UserId { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
    }
}
