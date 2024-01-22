using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums
{
	public record GetAllAlbumsQuery():IRequest<GetAllAlbumsResult>;
}
