using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDetailsDTO> GetUserDetails(string id);
        Task<UserPostDTO> PostUser(UserPostDTO userPostDTO);
        Task<UserPutDTO> PutUser(string id, UserPutDTO userPutDTO);
        Task<UserPatchDTO> PatchUser(string id, UserPatchDTO userPatchDTO);
        Task<UserDeleteDTO> DeleteUser(string id);
    }
}
