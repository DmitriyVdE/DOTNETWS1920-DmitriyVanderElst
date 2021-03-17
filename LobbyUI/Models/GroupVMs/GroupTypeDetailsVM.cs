using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupTypeDetailsVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("groups")]
        public ICollection<GroupVM> Groups { get; set; }
    }
}
