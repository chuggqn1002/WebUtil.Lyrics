

namespace WebUtil.Lyrics.Domain.Entities
{
    public class Song_Tag
    {
        public Guid Suid { get; set; }
        public int StId{ get; set; }
        public string? TagCode { get; set; }
        public string? TagName { get; set; }
        public int Status { get; set; }
    }
}
