using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class GroupType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}