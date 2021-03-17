using System.ComponentModel.DataAnnotations;

namespace LobbyApi.Models
{
    public class GroupUser
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int GroupUserTypeId { get; set; }

        public GroupUserType GroupUserType { get; set; }
    }
}