using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.DTOs
{
    public class UserPostDTO
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}