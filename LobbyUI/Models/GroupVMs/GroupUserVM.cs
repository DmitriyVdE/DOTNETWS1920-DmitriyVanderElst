using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupUserVM
    {
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("groupUserTypeId")]
        public int GroupUserTypeId { get; set; }
        [JsonPropertyName("groupUserType")]
        public string GroupUserType { get; set; }
    }
}
