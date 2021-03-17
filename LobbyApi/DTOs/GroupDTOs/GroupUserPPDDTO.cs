using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class GroupUserPPDDTO
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public int GroupUserTypeId { get; set; }
    }
}
