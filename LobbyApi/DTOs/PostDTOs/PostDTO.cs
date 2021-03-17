using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public UserDTO PostedBy { get; set; }

        public string PostType { get; set; }

#nullable enable
        public UserDTO? UserWall { get; set; }
#nullable enable
        public GroupDTO? GroupWall { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
