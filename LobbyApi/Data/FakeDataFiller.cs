using LobbyApi.Models;
using System;
using System.Linq;

namespace LobbyApi.Data
{
    public class FakeDataFiller
    {
        /**/
        private readonly LobbyContext _context;

        public FakeDataFiller(LobbyContext context)
        {
            _context = context;
            FillData();
        }

        private void FillData()
        {
            FillCountries();
            FillUserTypes();
            FillGroupTypes();
            FillGroupUserTypes();
            FillPostTypes();
        }

        private void FillCountries()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Belgium"
                });
                _context.SaveChanges();
            }
        }

        private void FillUserTypes()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Role
                {
                    Name = "Normal",
                    NormalizedName = "NORMAL",
                    Description = "Normal"
                });
                _context.Roles.Add(new Role
                {
                    Name = "Moderator",
                    NormalizedName = "MODERATOR",
                    Description = "Moderator"
                });
                _context.Roles.Add(new Role
                {
                    Name = "Developer",
                    NormalizedName = "DEVELOPER",
                    Description = "Developer"
                });
                _context.Roles.Add(new Role
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    Description = "SuperAdmin"
                });
                _context.SaveChanges();
            }

            //FillUsers();
        }

        /*
        private void FillUsers()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    UserName = "JustDenDimi",
                    Email = "dmitriy.vde@gmail.com",
                    PasswordHash = "Azerty123",
                    Firstname = "Dmitriy",
                    Lastname = "Van der Elst",
                    Birthdate = new DateTime(1996, 06, 27),
                    CountryId = 1,
                    UserTypeId = 3,
                    CreatedOn = DateTime.Now
                });
                _context.Users.Add(new User
                {
                    Username = "NotDimi",
                    Email = "not.dmitriy.vde@gmail.com",
                    Password = "Azerty123",
                    Firstname = "Not Dmitriy",
                    Lastname = "Van der Elst",
                    Birthdate = new DateTime(1996, 06, 27),
                    CountryId = 1,
                    UserTypeId = 2,
                    CreatedOn = DateTime.Now
                });
                _context.SaveChanges();
            }

            //FillFriends();
        }
        /**/

        /*
        private void FillFriends()
        {
            _context.Friends.Add(new Friend
            {
                UserId = 1,
                UserId2 = 2,
            });
            _context.SaveChanges();
        }
        /**/

        private void FillGroupTypes()
        {
            if (!_context.GroupTypes.Any())
            {
                _context.GroupTypes.Add(new GroupType
                {
                    Name = "Open"
                });
                _context.GroupTypes.Add(new GroupType
                {
                    Name = "Closed"
                });
                _context.GroupTypes.Add(new GroupType
                {
                    Name = "Secret"
                });
                _context.SaveChanges();
            }

            FillGroups();
        }

        private void FillGroups()
        {
            if (!_context.Groups.Any())
            {
                _context.Groups.Add(new Group
                {
                    Name = "Open Group",
                    Description = "This is an open group, anyone can join.",
                    GroupTypeId = 1,
                    CreatedOn = DateTime.Now
                });
                _context.Groups.Add(new Group
                {
                    Name = "Closed Group",
                    Description = "This is a closed group, it will still come up in searches, but you need an invite to join.",
                    GroupTypeId = 2,
                    CreatedOn = DateTime.Now
                });
                _context.Groups.Add(new Group
                {
                    Name = "Secret Group",
                    Description = "This is a secret group, it's hidden and you can only join with an invite from a member.",
                    GroupTypeId = 3,
                    CreatedOn = DateTime.Now
                });
                _context.SaveChanges();
            }
        }

        private void FillGroupUserTypes()
        {
            if (!_context.GroupUserTypes.Any())
            {
                _context.GroupUserTypes.Add(new GroupUserType
                {
                    Name = "Member"
                });
                _context.GroupUserTypes.Add(new GroupUserType
                {
                    Name = "Admin"
                });
                _context.GroupUserTypes.Add(new GroupUserType
                {
                    Name = "Owner"
                });
                _context.SaveChanges();
            }

            //FillGroupUsers();
        }

        /*
        private void FillGroupUsers()
        {
            if (!_context.GroupUsers.Any())
            {
                _context.GroupUsers.Add(new GroupUser
                {
                    GroupId = 1,
                    UserId = 1,
                    GroupUserTypeId = 1
                });
                _context.GroupUsers.Add(new GroupUser
                {
                    GroupId = 2,
                    UserId = 1,
                    GroupUserTypeId = 2
                });
                _context.GroupUsers.Add(new GroupUser
                {
                    GroupId = 3,
                    UserId = 1,
                    GroupUserTypeId = 3
                });
                _context.SaveChanges();
            }
        }
        /**/

        private void FillPostTypes()
        {
            if (!_context.PostTypes.Any())
            {
                _context.PostTypes.Add(new PostType
                {
                    Name = "UserWallPost"
                });
                _context.PostTypes.Add(new PostType
                {
                    Name = "GroupWallPost"
                });
                _context.SaveChanges();
            }

            //FillPosts();
        }

        /*
        private void FillPosts()
        {
            if (!_context.Posts.Any())
            {
                _context.Posts.Add(new Post
                {
                    Title = "Post on a user wall.",
                    Content = "This is a post posted on the wall of a user.",
                    UserId = 1,
                    PostTypeId = 1,
                    UserWallId = 1,
                    PostedOn = DateTime.Now
                });
                _context.Posts.Add(new Post
                {
                    Title = "Post on a open group wall.",
                    Content = "This is a post posted on the wall of an open group.",
                    UserId = 1,
                    PostTypeId = 2,
                    GroupWallId = 1,
                    PostedOn = DateTime.Now
                });
                _context.Posts.Add(new Post
                {
                    Title = "Post on a open closed wall.",
                    Content = "This is a post posted on the wall of an closed group.",
                    UserId = 1,
                    PostTypeId = 2,
                    GroupWallId = 2,
                    PostedOn = DateTime.Now
                });
                _context.Posts.Add(new Post
                {
                    Title = "Post on a open secret wall.",
                    Content = "This is a post posted on the wall of an secret group.",
                    UserId = 1,
                    PostTypeId = 2,
                    GroupWallId = 3,
                    PostedOn = DateTime.Now
                });
                _context.SaveChanges();
            }
        }
        /**/
    }
}
