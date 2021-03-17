using LobbyApi.Data;
using LobbyApi.DTOs;
using LobbyApi.Models;
using LobbyApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(LobbyContext context, ICountryRepository countryRepository)
        {
            _context = context;
            _countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountries()
        {
            return Ok(await _countryRepository.GetCountries().ConfigureAwait(false));
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryUsersDTO>> GetCountry(int id)
        {
            var country = await _countryRepository.GetCountry(id).ConfigureAwait(false);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }
    }
}