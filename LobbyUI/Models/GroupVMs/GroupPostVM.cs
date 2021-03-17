using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupPostVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("groupTypeId")]
        public int GroupTypeId { get; set; }
    }
}
