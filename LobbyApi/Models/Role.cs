using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class Role : IdentityRole
    {
        [Required]
        public string Description { get; set; }

        public ICollection<UserRole> RoleUsers { get; set; }
    }
}