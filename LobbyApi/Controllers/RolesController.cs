using LobbyApi.Data;
using LobbyApi.DTOs;
using LobbyApi.Models;
using LobbyApi.Repositories;
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
    public class RolesController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IRoleRepository _userTypeRepository;

        public RolesController(LobbyContext context, IRoleRepository userTypeRepository)
        {
            _context = context;
            _userTypeRepository = userTypeRepository;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            return Ok(await _userTypeRepository.GetRoles().ConfigureAwait(false));
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDetailsDTO>> GetRole(string id)
        {
            var role = await _userTypeRepository.GetRole(id).ConfigureAwait(false);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }
    }
}