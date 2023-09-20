using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Domain.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumCode { get; set; }
        public string AlbumName { get; set; }
        public DateTime Released { get; set; }
        public int Status { get; set; }
    }
}
