using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class UserDeleteDTO
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
