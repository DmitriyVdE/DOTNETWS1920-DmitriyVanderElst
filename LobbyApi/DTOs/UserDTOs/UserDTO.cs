using LobbyApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string From { get; set; }
        public ICollection<RoleDTO> Roles { get; set; }
        public string Token { get; set; }
    }
}