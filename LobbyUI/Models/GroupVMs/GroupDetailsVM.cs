
    using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class GroupDetailsVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("groupType")]
        public string GroupType { get; set; }
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
        [JsonPropertyName("members")]
        public ICollection<GroupUserVM> Members { get; set; }
        [JsonPropertyName("wall")]
        public ICollection<PostVM> Wall { get; set; }
    }
}
