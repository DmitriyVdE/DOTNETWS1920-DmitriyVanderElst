using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class GroupUserType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}