

namespace WebUtil.Lyrics.Domain.Entities
{
    public class Song_Line
    {
        public Guid Suid { get; set; }
        public int SlId{ get; set; }
        public string? Song_Text { get; set; }
        public int Line_Order { get; set; } 
        public int Param { get; set; }
    }
}
