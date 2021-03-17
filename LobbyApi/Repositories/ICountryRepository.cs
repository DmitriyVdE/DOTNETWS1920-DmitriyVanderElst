using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryDTO>> GetCountries();
        Task<CountryUsersDTO> GetCountry(int id);
    }
}
