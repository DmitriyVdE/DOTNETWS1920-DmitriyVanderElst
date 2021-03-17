using LobbyApi.Data;
using LobbyApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly LobbyContext _context;

        public CountryRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            return await _context.Countries
                .Select(c => new CountryDTO()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<CountryUsersDTO> GetCountry(int id)
        {
            return await _context.Countries.Include(u => u.Users)
                .Select(c => new CountryUsersDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Users = c.Users.Select(u => new UserDTO()
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        From = u.Country.Name,
                        Roles = u.UserRoles.Select(ur => new RoleDTO()
                        {
                            Name = ur.Role.Name
                        }).ToList()
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);
        }
    }
}
