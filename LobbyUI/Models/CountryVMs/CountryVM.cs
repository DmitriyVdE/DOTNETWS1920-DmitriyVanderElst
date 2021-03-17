using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class CountryVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}
