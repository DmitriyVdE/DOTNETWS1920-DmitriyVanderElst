using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupUserPPDVM
    {
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("groupUserTypeId")]
        public int GroupUserTypeId { get; set; }
    }
}
