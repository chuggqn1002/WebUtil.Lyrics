using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetAllSongs
{
	public record GetAllSongsResult(IEnumerable<Domain.Entities.Song> Songs);
}
