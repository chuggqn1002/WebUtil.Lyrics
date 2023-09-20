
using WebUtil.Lyrics.Domain.Enums;

namespace WebUtil.Lyrics.Domain.Entities
{
    public class User
    {
        public long Userid { get; set; }
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public int Status { get; set; } = 0;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public User_Profile? UserProfile { get; set; }

    }
}
