using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class PostPutDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
