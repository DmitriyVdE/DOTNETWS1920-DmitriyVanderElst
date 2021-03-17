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
    public class UsersController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(LobbyContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsers().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserDetails(string id)
        {
            var user = await _userRepository.GetUserDetails(id).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserPostDTO>> PostUser(UserPostDTO userPostDTO)
        {
            var userResult = await _userRepository.PostUser(userPostDTO).ConfigureAwait(false);

            return CreatedAtAction("GetUserDetails", new { id = userResult.Id }, userResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, UserPutDTO userPutDTO)
        {
            if (id != userPutDTO.Id)
            {
                return BadRequest();
            }

            var userResult = await _userRepository.PutUser(id, userPutDTO).ConfigureAwait(false);

            if (userResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(string id, UserPatchDTO userPatchDTO)
        {
            if (id != userPatchDTO.Id)
            {
                return BadRequest();
            }

            var userResult = await _userRepository.PatchUser(id, userPatchDTO).ConfigureAwait(false);

            if (userResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDeleteDTO>> DeleteUser(string id)
        {
            var userResult = await _userRepository.DeleteUser(id).ConfigureAwait(false);

            if (userResult == null)
            {
                return NotFound();
            }

            return userResult;
        }
    }
}