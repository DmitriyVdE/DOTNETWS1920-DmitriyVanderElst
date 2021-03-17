using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class PostPostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public int PostTypeId { get; set; }

#nullable enable
        public string? UserWallId { get; set; }
#nullable enable
        public int? GroupWallId { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
