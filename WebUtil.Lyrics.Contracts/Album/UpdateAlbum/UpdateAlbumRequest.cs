using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Album.UpdateAlbum
{
	public record UpdateAlbumRequest
	(
		string AlbumCode,
		string AlbumName,
		DateTime Released,
		int Status
	);
}
