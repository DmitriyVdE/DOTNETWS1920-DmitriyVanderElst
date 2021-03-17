using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostDTO>> GetPosts();
        Task<PostDTO> GetPost(int id);
        Task<PostPostDTO> PostPost(PostPostDTO postPostDTO);
        Task<PostPutDTO> PutPost(PostPutDTO postPutDTO);
        Task<PostDeleteDTO> DeletePost(int id);
    }
}
