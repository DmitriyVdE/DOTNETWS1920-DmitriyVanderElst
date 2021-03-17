using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LobbyUI.Models
{
    public class UserDetailsVM
    {
        [JsonPropertyName("id")]
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
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("from")]
        public CountryVM From { get; set; }

        [JsonPropertyName("roles")]
        public ICollection<RoleVM> Roles { get; set; }

        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("friends")]
        public ICollection<UserVM> Friends { get; set; }

        [JsonPropertyName("groups")]
        public ICollection<GroupVM> Groups { get; set; }

        [JsonPropertyName("posted")]
        public ICollection<PostVM> Posted { get; set; }

        [JsonPropertyName("wall")]
        public ICollection<PostVM> Wall { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
