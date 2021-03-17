using LobbyApi.Data;
using LobbyApi.DTOs;
using LobbyApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LobbyContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(LobbyContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return await _context.Users
                .Include(u => u.Country)
                .Include(u => u.UserRoles)
                .Select(u => new UserDTO()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    From = u.Country.Name,
                    Roles = u.UserRoles.Select(ur => new RoleDTO()
                    {
                        Id = ur.Role.Id,
                        Name = ur.Role.Name
                    }).ToList()
                })
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<UserDetailsDTO> GetUserDetails(string id)
        {
            return await _context.Users
                .Include(u => u.Country)
                .Include(u => u.UserRoles)
                .Include(u => u.UserFriends)
                .Include(u => u.UserGroups)
                .Include(u => u.Posts)
                .Include(u => u.UserWall)
                .Select(u => new UserDetailsDTO()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    Birthdate = u.Birthdate,
                    From = new CountryDTO()
                    {
                        Id = u.Country.Id,
                        Name = u.Country.Name
                    },
                    Roles = u.UserRoles.Select(ur => new RoleDTO()
                    {
                        Id = ur.Role.Id,
                        Name = ur.Role.Name
                    }).ToList(),
                    CreatedOn = u.CreatedOn,
                    Friends = u.UserFriends.Select(f => new UserDTO()
                    {
                        Id = f.User2.Id,
                        UserName = f.User2.UserName,
                        From = f.User2.Country.Name,
                        Roles = f.User2.UserRoles.Select(ur => new RoleDTO()
                        {
                            Id = ur.Role.Id,
                            Name = ur.Role.Name
                        }).ToList()
                    }).ToList(),
                    Groups = u.UserGroups.Select(g => new GroupDTO()
                    {
                        Id = g.Group.Id,
                        Name = g.Group.Name,
                        Description = g.Group.Description,
                        GroupType = g.Group.GroupType.Name
                    }).ToList(),
                    Posted = u.Posts.Select(p => new PostDTO()
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
                    }).ToList(),
                    Wall = u.UserWall.Select(p => new PostDTO()
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

        public async Task<UserPostDTO> PostUser(UserPostDTO userPostDTO)
        {
            if (userPostDTO == null) { throw new ArgumentNullException(nameof(userPostDTO)); }

            var user = new User()
            {
                UserName = userPostDTO.UserName,
                Email = userPostDTO.Email,
                Firstname = userPostDTO.Firstname,
                Lastname = userPostDTO.Lastname,
                Birthdate = userPostDTO.Birthdate,
                CountryId = userPostDTO.CountryId,
                CreatedOn = DateTime.Now
            };

            _ = await _userManager.CreateAsync(user, userPostDTO.Password).ConfigureAwait(false);

            _ = await _userManager.AddToRolesAsync(user, userPostDTO.Roles).ConfigureAwait(false);

            userPostDTO.Id = user.Id;

            return userPostDTO;
        }

        public async Task<UserPutDTO> PutUser(string id, UserPutDTO userPutDTO)
        {
            if (userPutDTO == null) { throw new ArgumentNullException(nameof(userPutDTO)); }

            try
            {
                User user = await _context.Users.Include(u => u.UserFriends).FirstOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
                user.UserName = userPutDTO.UserName;
                user.Email = userPutDTO.Email;
                user.Firstname = userPutDTO.Firstname;
                user.Lastname = userPutDTO.Lastname;
                user.Birthdate = userPutDTO.Birthdate;
                user.CountryId = userPutDTO.Country.Id;

                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                _ = await _userManager.RemoveFromRolesAsync(user, roles.ToArray()).ConfigureAwait(false);

                _ = await _userManager.AddToRolesAsync(user, userPutDTO.Roles.ToList().Select(x => x.Name).ToArray()).ConfigureAwait(false);

                _ = await _userManager.UpdateAsync(user).ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return userPutDTO;
        }

        public async Task<UserPatchDTO> PatchUser(string id, UserPatchDTO userPatchDTO)
        {
            if (userPatchDTO == null) { throw new ArgumentNullException(nameof(userPatchDTO)); }

            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
                _ = await _userManager.ChangePasswordAsync(user, userPatchDTO.CurrentPassword, userPatchDTO.NewPassword).ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return userPatchDTO;
        }

        public async Task<UserDeleteDTO> DeleteUser(string id)
        {
            var user = await _context.Users
                .Include(u => u.UserFriends)
                .Include(u => u.FriendUsers)
                .Include(u => u.UserGroups)
                .Include(u => u.Posts)
                .Include(u => u.UserWall)
                .FirstOrDefaultAsync(c => c.Id == id)
                .ConfigureAwait(false);

            if (user == null)
            {
                return null;
            }

            if (user.UserFriends.Count > 0)
            {
                _context.Friends.RemoveRange(user.UserFriends);
            }

            if (user.FriendUsers.Count > 0)
            {
                _context.Friends.RemoveRange(user.FriendUsers);
            }

            _context.Posts.RemoveRange(user.Posts);
            _context.Posts.RemoveRange(user.UserWall);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            await _userManager.DeleteAsync(user).ConfigureAwait(false);

            return new UserDeleteDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
