using System.ComponentModel.DataAnnotations;

namespace LobbyApi.DTOs
{
    public class UserPatchDTO
    {
        public string Id { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}