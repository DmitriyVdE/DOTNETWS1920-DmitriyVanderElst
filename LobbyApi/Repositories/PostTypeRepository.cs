using LobbyApi.Data;
using LobbyApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class PostTypeRepository : IPostTypeRepository
    {
        private readonly LobbyContext _context;

        public PostTypeRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostTypeDTO>> GetPostTypes()
        {
            return await _context.PostTypes
                .Select(u => new PostTypeDTO()
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<PostTypeDTO> GetPostType(int id)
        {
            return await _context.PostTypes
                .Select(u => new PostTypeDTO()
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }
    }
}
