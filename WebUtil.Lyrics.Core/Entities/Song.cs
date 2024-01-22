using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Domain.Entities
{
    public class Song
    {
        public int Sid { get; set; }
        public Guid Suid { get; set; }
        public string SongCode { get; set; }
        public string? Title { get; set; }
        public string? Album { get; set; }
        public string? AlbumCode { get; set; }
        public string? AlbumName { get; set; }
        public string? Author { get; set; }
        public string? AuthorCode { get; set; }
        public string? AuthorName { get; set; }
        public string? Singer { get; set; }
        public string? SingerCode { get; set; }
        public string? SingerName { get; set; }
        public string? ImgUrl { get; set; }
        public string? YtbCode { get; set; }
        public string? VideoLink { get; set; }
        public string? Description { get; set; }
		public DateTime Released { get; set; }
        public int Status { get; set; }
        public IEnumerable<Song_Line> Song_Lines { get; set; }

        public IEnumerable<Song_Tag> Song_Tags { get; set;}
		public IEnumerable<Song_Category> Song_Categories { get; set; }


	}
}
