using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums
{
	public record GetAllAlbumsResult(IEnumerable<Domain.Entities.Album> albumList);
}
