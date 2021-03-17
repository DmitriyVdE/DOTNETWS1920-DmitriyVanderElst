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
    public class GroupTypesController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IGroupTypeRepository _groupTypeRepository;

        public GroupTypesController(LobbyContext context, IGroupTypeRepository groupTypeRepository)
        {
            _context = context;
            _groupTypeRepository = groupTypeRepository;
        }

        // GET: api/GroupTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupTypeDTO>>> GetGroupType()
        {
            return Ok(await _groupTypeRepository.GetGroupTypes().ConfigureAwait(false));
        }

        // GET: api/GroupTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTypeDetailsDTO>> GetGroupType(int id)
        {
            var groupType = await _groupTypeRepository.GetGroupType(id).ConfigureAwait(false);

            if (groupType == null)
            {
                return NotFound();
            }

            return groupType;
        }
    }
}