using LobbyApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.DTOs
{
    public class UserPutDTO
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public CountryDTO Country { get; set; }

        [Required]
        public ICollection<RoleDTO> Roles { get; set; }
    }
}