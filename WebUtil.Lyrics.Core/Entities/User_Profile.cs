
namespace WebUtil.Lyrics.Domain.Entities
{
    public class User_Profile
    {
        public int ProfileId { get; set; }
        public Guid Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Middle { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public string TelNum { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}