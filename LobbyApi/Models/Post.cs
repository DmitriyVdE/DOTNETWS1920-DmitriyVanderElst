using System;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int PostTypeId { get; set; }

        public PostType PostType { get; set; }

#nullable enable
        public string? UserWallId { get; set; }
#nullable enable
        public User? UserWall { get; set; }

#nullable enable
        public int? GroupWallId { get; set; }
#nullable enable
        public Group? GroupWall { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }
    }
}