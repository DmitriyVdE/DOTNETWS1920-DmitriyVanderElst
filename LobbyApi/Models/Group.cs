using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int GroupTypeId { get; set; }

        public GroupType GroupType { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }
        public ICollection<Post> GroupWall { get; set; }
    }
}