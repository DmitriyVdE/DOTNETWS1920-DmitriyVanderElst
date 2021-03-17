using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        #nullable enable
        public int? CountryId { get; set; }
        #nullable enable
        public Country? Country { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Friend> UserFriends { get; set; }
        public ICollection<Friend> FriendUsers { get; set; }
        public ICollection<GroupUser> UserGroups { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Post> UserWall { get; set; }
    }
}