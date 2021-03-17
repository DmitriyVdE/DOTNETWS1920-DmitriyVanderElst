using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDTO>> GetRoles();
        Task<RoleDetailsDTO> GetRole(string id);
    }
}
