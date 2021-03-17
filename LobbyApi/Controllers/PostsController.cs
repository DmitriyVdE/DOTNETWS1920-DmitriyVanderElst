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
    public class PostsController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IPostRepository _postRepository;

        public PostsController(LobbyContext context, IPostRepository postRepository)
        {
            _context = context;
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            return Ok(await _postRepository.GetPosts().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id).ConfigureAwait(false);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> PostPost(PostPostDTO postPostDTO)
        {
            if (postPostDTO == null)
            {
                return BadRequest();
            }

            var postResult = await _postRepository.PostPost(postPostDTO).ConfigureAwait(false);

            if (postResult == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetPost", new { id = postPostDTO.Id }, postPostDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostPutDTO postPutDTO)
        {
            if (postPutDTO == null)
            {
                return BadRequest();
            }

            if (id != postPutDTO.Id)
            {
                return BadRequest();
            }

            var postResult = await _postRepository.PutPost(postPutDTO).ConfigureAwait(false);

            if (postResult == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PostDeleteDTO>> DeletePost(int id)
        {
            var postResult = await _postRepository.DeletePost(id).ConfigureAwait(false);

            if (postResult == null)
            {
                return NotFound();
            }

            return new PostDeleteDTO()
            {
                Id = postResult.Id,
                Title = postResult.Title,
                Content = postResult.Content,
                PosterId = postResult.PosterId,
                Postername = postResult.Postername
            };
        }
    }
}