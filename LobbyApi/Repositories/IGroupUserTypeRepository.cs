using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IGroupUserTypeRepository
    {
        Task<IEnumerable<GroupUserTypeDTO>> GetGroupUserTypes();
        Task<GroupUserTypeDTO> GetGroupUserType(int id);
    }
}
