using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Contracts.SongContract.GetAllSong;

namespace WebUtil.Lyrics.Contracts.SongContract.SearchSong
{
	public record SearchSongResponse(IEnumerable<SongResponse> songs);
}
