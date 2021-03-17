using LobbyApi.Data;
using LobbyApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class GroupUserTypeRepository : IGroupUserTypeRepository
    {
        private readonly LobbyContext _context;

        public GroupUserTypeRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupUserTypeDTO>> GetGroupUserTypes()
        {
            return await _context.GroupUserTypes
                .Select(u => new GroupUserTypeDTO()
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<GroupUserTypeDTO> GetGroupUserType(int id)
        {
            var groupUserType = await _context.GroupUserTypes
                .Select(u => new GroupUserTypeDTO()
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);

            if (groupUserType == null)
            {
                return null;
            }

            return groupUserType;
        }
    }
}
