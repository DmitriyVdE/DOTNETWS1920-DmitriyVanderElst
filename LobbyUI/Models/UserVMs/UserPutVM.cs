using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserPutVM
    {
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; }

        [JsonPropertyName("userName")]
        [Required]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }


        [DataType(DataType.Date)]
        [JsonPropertyName("birthdate")]
        [Required]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("from")]
        [Required]
        public CountryVM Country { get; set; }

        [JsonPropertyName("roles")]
        public ICollection<RoleVM> Roles { get; set; }
    }
}