using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IFriendRepository
    {
        Task<IEnumerable<FriendDTO>> GetFriend(string id);
        Task<FriendPostDTO> PostFriend(FriendPostDTO friendPostDTO);
        Task<FriendDeleteDTO> DeleteFriend(FriendDeleteDTO friendDeleteDTO);
    }
}
