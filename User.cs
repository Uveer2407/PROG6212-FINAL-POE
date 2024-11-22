namespace CMCS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
