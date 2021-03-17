using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class GroupUserDTO
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int GroupUserTypeId { get; set; }
        public string GroupUserType { get; set; }
    }
}
