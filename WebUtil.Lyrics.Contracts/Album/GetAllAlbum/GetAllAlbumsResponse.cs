using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Album.GetAllAlbum
{
	public record GetAllAlbumsResponse(IEnumerable<AlbumRecord> AlbumList);
	public record AlbumRecord(
		int AlbumId,
		string AlbumCode,
		string AlbumName,
		DateTime Released,
		int Status);
}
