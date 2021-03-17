using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class RoleDetailsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
