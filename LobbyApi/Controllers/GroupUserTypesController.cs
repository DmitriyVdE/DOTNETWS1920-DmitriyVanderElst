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
    public class GroupUserTypesController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IGroupUserTypeRepository _groupUserTypeRepository;

        public GroupUserTypesController(LobbyContext context, IGroupUserTypeRepository groupUserTypeRepository)
        {
            _context = context;
            _groupUserTypeRepository = groupUserTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupUserTypeDTO>>> GetGroupUserType()
        {
            return Ok(await _groupUserTypeRepository.GetGroupUserTypes().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupUserTypeDTO>> GetGroupUserType(int id)
        {
            var groupUserType = await _groupUserTypeRepository.GetGroupUserType(id).ConfigureAwait(false);

            if (groupUserType == null)
            {
                return NotFound();
            }

            return groupUserType;
        }
    }
}