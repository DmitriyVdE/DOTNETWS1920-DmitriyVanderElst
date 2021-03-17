using LobbyApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class UserDetailsDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }

        public CountryDTO From { get; set; }

        public ICollection<RoleDTO> Roles { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<UserDTO> Friends { get; set; }

        public ICollection<GroupDTO> Groups { get; set; }

        public ICollection<PostDTO> Posted { get; set; }

        public ICollection<PostDTO> Wall { get; set; }

        public string Token { get; set; }
    }
}
