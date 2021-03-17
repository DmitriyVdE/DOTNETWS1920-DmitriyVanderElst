using LobbyApi.Data;
using LobbyApi.DTOs;
using LobbyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly LobbyContext _context;

        public PostRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostDTO>> GetPosts()
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.User.Country)
                .Include(p => p.PostType)
                .Include(p => p.UserWall)
                .Include(p => p.UserWall.Country)
                .Include(p => p.GroupWall)
                .Include(p => p.GroupWall.GroupType)
                .Select(p => new PostDTO()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    PostedBy = new UserDTO()
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        From = p.User.Country.Name,
                        Roles = p.User.UserRoles.Select(ur => new RoleDTO()
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }).ToList()
                    },
                    PostType = p.PostType.Name,
                    UserWall = new UserDTO()
                    {
                        Id = p.UserWall.Id,
                        UserName = p.UserWall.UserName,
                        From = p.UserWall.Country.Name,
                        Roles = p.UserWall.UserRoles.Select(ur => new RoleDTO()
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }).ToList()
                    },
                    GroupWall = new GroupDTO()
                    {
                        Id = p.GroupWall.Id,
                        Name = p.GroupWall.Name,
                        Description = p.GroupWall.Description,
                        GroupType = p.GroupWall.GroupType.Name
                    },
                    PostedOn = p.PostedOn
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<PostDTO> GetPost(int id)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.User.Country)
                .Include(p => p.PostType)
                .Include(p => p.UserWall)
                .Include(p => p.UserWall.Country)
                .Include(p => p.GroupWall)
                .Include(p => p.GroupWall.GroupType)
                .Select(p => new PostDTO()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    PostedBy = new UserDTO()
                    {
                        Id = p.User.Id,
                        UserName = p.User.UserName,
                        From = p.User.Country.Name,
                        Roles = p.User.UserRoles.Select(ur => new RoleDTO()
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }).ToList()
                    },
                    PostType = p.PostType.Name,
                    UserWall = new UserDTO()
                    {
                        Id = p.UserWall.Id,
                        UserName = p.UserWall.UserName,
                        From = p.UserWall.Country.Name,
                        Roles = p.UserWall.UserRoles.Select(ur => new RoleDTO()
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }).ToList()
                    },
                    GroupWall = new GroupDTO()
                    {
                        Id = p.GroupWall.Id,
                        Name = p.GroupWall.Name,
                        Description = p.GroupWall.Description,
                        GroupType = p.GroupWall.GroupType.Name
                    },
                    PostedOn = p.PostedOn
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<PostPostDTO> PostPost(PostPostDTO postPostDTO)
        {
            if (postPostDTO == null) { throw new ArgumentNullException(nameof(postPostDTO)); }

            var postResult = _context.Posts.Add(new Post()
            {
                Title = postPostDTO.Title,
                Content = postPostDTO.Content,
                UserId = postPostDTO.UserId,
                PostTypeId = postPostDTO.PostTypeId,
                UserWallId = postPostDTO.UserWallId,
                GroupWallId = postPostDTO.GroupWallId,
                PostedOn = DateTime.Now
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            postPostDTO.Id = postResult.Entity.Id;
            postPostDTO.PostedOn = postResult.Entity.PostedOn;

            return postPostDTO;
        }

        public async Task<PostPutDTO> PutPost(PostPutDTO postPutDTO)
        {
            if (postPutDTO == null) { throw new ArgumentNullException(nameof(postPutDTO)); }

            try
            {
                Post post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postPutDTO.Id).ConfigureAwait(false);

                post.Title = postPutDTO.Title;
                post.Content = postPutDTO.Content;

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(postPutDTO.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return postPutDTO;
        }

        public async Task<PostDeleteDTO> DeletePost(int id)
        {
            var post = await _context.Posts
                .Include(g => g.User)
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            if (post == null)
            {
                return null;
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new PostDeleteDTO()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                PosterId = post.UserId,
                Postername = post.User.UserName
            };
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
