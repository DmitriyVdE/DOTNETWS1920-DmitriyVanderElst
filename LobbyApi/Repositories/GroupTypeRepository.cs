using LobbyApi.Data;
using LobbyApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class GroupTypeRepository : IGroupTypeRepository
    {
        private readonly LobbyContext _context;

        public GroupTypeRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupTypeDTO>> GetGroupTypes()
        {
            return await _context.GroupTypes
                .Select(u => new GroupTypeDTO()
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<GroupTypeDetailsDTO> GetGroupType(int id)
        {
            return await _context.GroupTypes
                .Include(u => u.Groups)
                .Select(u => new GroupTypeDetailsDTO()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Groups = u.Groups.Select(f => new GroupDTO()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        GroupType = f.GroupType.Name
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }
    }
}
