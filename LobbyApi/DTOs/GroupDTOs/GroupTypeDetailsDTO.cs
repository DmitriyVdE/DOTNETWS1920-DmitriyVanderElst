using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class GroupTypeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupDTO> Groups { get; set; }
    }
}
