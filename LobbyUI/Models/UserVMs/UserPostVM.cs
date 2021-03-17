using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserPostVM
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("userName")]
        [Required]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [JsonPropertyName("birthdate")]
        [Required]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("countryId")]
        [Required]
        public int CountryId { get; set; }

        [JsonPropertyName("roles")]
        public string[] Roles { get; set; }
    }
}