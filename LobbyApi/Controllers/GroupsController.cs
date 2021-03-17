using LobbyApi.Data;
using LobbyApi.DTOs;
using LobbyApi.Models;
using LobbyApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IGroupRepository _groupRepository;

        public GroupsController(LobbyContext context, IGroupRepository groupRepository)
        {
            _context = context;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups()
        {
            return Ok(await _groupRepository.GetGroups().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDetailsDTO>> GetGroup(int id)
        {
            var @group = await _groupRepository.GetGroup(id).ConfigureAwait(false);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        [HttpPost]
        public async Task<ActionResult<GroupDetailsDTO>> PostGroup(GroupPostDTO groupPostDTO)
        {
            var groupResult = await _groupRepository.PostGroup(groupPostDTO).ConfigureAwait(false);

            return CreatedAtAction("GetGroup", new { id = groupResult.Id }, groupResult);
        }

        // WHAT TO DO IN CASE OF ADDING DUPLICATE USERS?
        [HttpPost("{id}/users")]
        public async Task<ActionResult<GroupDetailsDTO>> AddUser(int id, GroupUserPPDDTO groupUserPPDDTO)
        {
            if (groupUserPPDDTO == null)
            {
                return BadRequest();
            }

            if (id != groupUserPPDDTO.GroupId)
            {
                return BadRequest();
            }

            var groupResult = await _groupRepository.AddUser(groupUserPPDDTO).ConfigureAwait(false);

            return CreatedAtAction("GetGroup", new { id = groupResult.GroupId }, groupResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, GroupPutDTO groupPutDTO)
        {
            if (groupPutDTO == null)
            {
                return BadRequest();
            }

            if (id != groupPutDTO.Id)
            {
                return BadRequest();
            }

            var groupResult = await _groupRepository.PutGroup(groupPutDTO).ConfigureAwait(false);

            if (groupResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}/users")]
        public async Task<IActionResult> PutUser(int id, GroupUserPPDDTO groupUserPPDDTO)
        {
            if (groupUserPPDDTO == null)
            {
                return BadRequest();
            }

            if (id != groupUserPPDDTO.GroupId)
            {
                return BadRequest();
            }

            var groupResult = await _groupRepository.PutUser(groupUserPPDDTO).ConfigureAwait(false);

            if (groupResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupDeleteDTO>> DeleteGroup(int id)
        {
            var groupResult = await _groupRepository.DeleteGroup(id).ConfigureAwait(false);

            if (groupResult == null)
            {
                return NotFound();
            }

            return groupResult;
        }

        [HttpDelete("{id}/users")]
        public async Task<ActionResult<GroupDetailsDTO>> DeleteUser(int id, GroupUserPPDDTO groupUserPPDDTO)
        {
            if (groupUserPPDDTO == null)
            {
                return BadRequest();
            }

            if (id != groupUserPPDDTO.GroupId)
            {
                return BadRequest();
            }

            var groupResult = await _groupRepository.DeleteUser(groupUserPPDDTO).ConfigureAwait(false);

            if (groupResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetGroup", new { id = groupUserPPDDTO.GroupId }, groupUserPPDDTO);
        }
    }
}