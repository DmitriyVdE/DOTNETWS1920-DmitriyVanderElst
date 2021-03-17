using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IPostTypeRepository
    {
        Task<IEnumerable<PostTypeDTO>> GetPostTypes();
        Task<PostTypeDTO> GetPostType(int id);
    }
}
