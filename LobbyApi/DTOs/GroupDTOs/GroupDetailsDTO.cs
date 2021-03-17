using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class GroupDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupType { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<GroupUserDTO> Members { get; set; }
        public ICollection<PostDTO> Wall { get; set; }
    }
}
