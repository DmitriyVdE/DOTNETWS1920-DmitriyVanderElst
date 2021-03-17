using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LobbyApi.Data;
using LobbyApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LobbyApi.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly LobbyContext _context;

        public RoleRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            return await _context.Roles
                   .Select(u => new RoleDTO()
                   {
                       Id = u.Id,
                       Name = u.Name
                   })
                   .AsNoTracking()
                   .ToListAsync()
                   .ConfigureAwait(false);
        }

        public async Task<RoleDetailsDTO> GetRole(string id)
        {
            return await _context.Roles
                .Include(u => u.RoleUsers)
                .Select(u => new RoleDetailsDTO()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Users = u.RoleUsers.Select(f => new UserDTO()
                    {
                        Id = f.UserId,
                        UserName = f.User.UserName,
                        From = f.User.Country.Name,
                        Roles = f.User.UserRoles.Select(ur => new RoleDTO()
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }).ToList()
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }
    }
}
