using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LobbyApi.Data;
using LobbyApi.Models;
using LobbyApi.DTOs;
using LobbyApi.Repositories;

namespace LobbyApi.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IFriendRepository _friendRepository;

        public FriendsController(LobbyContext context, IFriendRepository friendRepository)
        {
            _context = context;
            _friendRepository = friendRepository;
        }

        // GET: api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FriendDTO>>> GetFriend(string id)
        {
            var friend = await _friendRepository.GetFriend(id).ConfigureAwait(false);

            if (friend == null)
            {
                return NotFound();
            }

            return friend.ToList();
        }

        // POST: api/Friends
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<IEnumerable<FriendDTO>>> PostFriend(FriendPostDTO friendPostDTO)
        {
            var friendResult = await _friendRepository.PostFriend(friendPostDTO).ConfigureAwait(false);

            return CreatedAtAction("GetFriend", new { id = friendResult.UserId }, friendResult);
        }

        // DELETE: api/Friends/5
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<FriendDTO>>> DeleteFriend(FriendDeleteDTO friendDeleteDTO)
        {
            var friendResult = await _friendRepository.DeleteFriend(friendDeleteDTO).ConfigureAwait(false);

            if (friendResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetFriend", new { id = friendDeleteDTO.UserId }, friendDeleteDTO); ;
        }
    }
}
