using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<GroupDTO>> GetGroups();
        Task<GroupDetailsDTO> GetGroup(int id);
        Task<GroupPostDTO> PostGroup(GroupPostDTO groupPostDTO);
        Task<GroupUserPPDDTO> AddUser(GroupUserPPDDTO groupUserPPDDTO);
        Task<GroupPutDTO> PutGroup(GroupPutDTO groupPutDTO);
        Task<GroupUserPPDDTO> PutUser(GroupUserPPDDTO groupUserPPDDTO);
        Task<GroupDeleteDTO> DeleteGroup(int id);
        Task<GroupUserPPDDTO> DeleteUser(GroupUserPPDDTO groupUserPPDDTO);
    }
}
