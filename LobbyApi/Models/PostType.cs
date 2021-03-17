using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class PostType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}