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
    public class GroupRepository : IGroupRepository
    {
        private readonly LobbyContext _context;

        public GroupRepository(LobbyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupDTO>> GetGroups()
        {
            return await _context.Groups
                .Include(g => g.GroupType)
                .Select(g => new GroupDTO()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    GroupType = g.GroupType.Name
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task<GroupDetailsDTO> GetGroup(int id)
        {
            return await _context.Groups
                .Include(g => g.GroupUsers)
                .Include(g => g.GroupWall)
                .Select(g => new GroupDetailsDTO()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    GroupType = g.GroupType.Name,
                    CreatedOn = g.CreatedOn,
                    Members = g.GroupUsers.Select(m => new GroupUserDTO()
                    {
                        GroupId = m.GroupId,
                        UserId = m.UserId,
                        UserName = m.User.UserName,
                        GroupUserTypeId = m.GroupUserTypeId,
                        GroupUserType = m.GroupUserType.Name
                    }).ToList(),
                    Wall = g.GroupWall.Select(p => new PostDTO()
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
                    }).ToList()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<GroupPostDTO> PostGroup(GroupPostDTO groupPostDTO)
        {
            if (groupPostDTO == null) { throw new ArgumentNullException(nameof(groupPostDTO)); }

            var groupResult = _context.Groups.Add(new Group()
            {
                Name = groupPostDTO.Name,
                Description = groupPostDTO.Description,
                GroupTypeId = groupPostDTO.GroupTypeId,
                CreatedOn = DateTime.Now
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            groupPostDTO.Id = groupResult.Entity.Id;

            return groupPostDTO;
        }

        public async Task<GroupUserPPDDTO> AddUser(GroupUserPPDDTO groupUserPPDDTO)
        {
            if (groupUserPPDDTO == null) { throw new ArgumentNullException(nameof(groupUserPPDDTO)); }

            _context.GroupUsers.Add(new GroupUser()
            {
                GroupId = groupUserPPDDTO.GroupId,
                UserId = groupUserPPDDTO.UserId,
                GroupUserTypeId = groupUserPPDDTO.GroupUserTypeId
            });

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return groupUserPPDDTO;
        }

        public async Task<GroupPutDTO> PutGroup(GroupPutDTO groupPutDTO)
        {
            if (groupPutDTO == null) { throw new ArgumentNullException(nameof(groupPutDTO)); }

            try
            {
                Group group = await _context.Groups.Include(g => g.GroupUsers).FirstOrDefaultAsync(g => g.Id == groupPutDTO.Id).ConfigureAwait(false);
                group.Name = groupPutDTO.Name;
                group.Description = groupPutDTO.Description;
                group.GroupTypeId = groupPutDTO.GroupTypeId;

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(groupPutDTO.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return groupPutDTO;
        }

        public async Task<GroupUserPPDDTO> PutUser(GroupUserPPDDTO groupUserPPDDTO)
        {
            if (groupUserPPDDTO == null) { throw new ArgumentNullException(nameof(groupUserPPDDTO)); }

            try
            {
                GroupUser groupUser = await _context.GroupUsers
                    .Where(gu => gu.GroupId == groupUserPPDDTO.GroupId && gu.UserId == groupUserPPDDTO.UserId)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
                groupUser.GroupUserTypeId = groupUserPPDDTO.GroupUserTypeId;

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupUserExists(groupUserPPDDTO.GroupId, groupUserPPDDTO.UserId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return groupUserPPDDTO;
        }

        public async Task<GroupDeleteDTO> DeleteGroup(int id)
        {
            var group = await _context.Groups
                .Include(g => g.GroupUsers)
                .Include(g => g.GroupWall)
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            if (group == null)
            {
                return null;
            }

            _context.GroupUsers.RemoveRange(group.GroupUsers);
            _context.Posts.RemoveRange(group.GroupWall);
            _context.Groups.Remove(group);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new GroupDeleteDTO()
            {
                Id = group.Id,
                Name = group.Name
            };
        }

        public async Task<GroupUserPPDDTO> DeleteUser(GroupUserPPDDTO groupUserPPDDTO)
        {
            var groupUserResult = await _context.GroupUsers
                   .Where(gu => gu.GroupId == groupUserPPDDTO.GroupId && gu.UserId == groupUserPPDDTO.UserId)
                   .FirstOrDefaultAsync()
                   .ConfigureAwait(false);

            if (groupUserResult == null)
            {
                return null;
            }

            _context.GroupUsers.Remove(groupUserResult);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return groupUserPPDDTO;
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }

        private bool GroupUserExists(int groupId, string userId)
        {
            return _context.GroupUsers.Any(e => e.GroupId == groupId && e.UserId == userId);
        }
    }
}
