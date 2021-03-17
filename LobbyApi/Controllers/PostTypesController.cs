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
    public class PostTypesController : ControllerBase
    {
        private readonly LobbyContext _context;
        private readonly IPostTypeRepository _postTypeRepository;

        public PostTypesController(LobbyContext context, IPostTypeRepository postTypeRepository)
        {
            _context = context;
            _postTypeRepository = postTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostTypeDTO>>> GetPostTypes()
        {
            return Ok(await _postTypeRepository.GetPostTypes().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostTypeDTO>> GetPostType(int id)
        {
            var postType = await _postTypeRepository.GetPostType(id).ConfigureAwait(false);

            if (postType == null)
            {
                return NotFound();
            }

            return postType;
        }
    }
}