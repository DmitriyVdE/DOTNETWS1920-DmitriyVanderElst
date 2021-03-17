using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IGroupTypeRepository
    {
        Task<IEnumerable<GroupTypeDTO>> GetGroupTypes();
        Task<GroupTypeDetailsDTO> GetGroupType(int id);
    }
}
