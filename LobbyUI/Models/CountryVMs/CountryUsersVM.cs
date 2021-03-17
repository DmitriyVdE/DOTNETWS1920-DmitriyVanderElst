using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class CountryUsersVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("users")]
        public ICollection<UserVM> Users { get; set; }
    }
}
