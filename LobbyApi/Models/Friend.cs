namespace LobbyApi.Models
{
    public class Friend
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string UserId2 { get; set; }
        public User User2 { get; set; }
    }
}