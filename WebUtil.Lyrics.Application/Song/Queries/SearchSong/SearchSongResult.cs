using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Songs.Queries.SearchSong
{
	public record SearchSongResult(IEnumerable<Domain.Entities.Song> songs);
}
