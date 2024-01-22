using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Categories.Commands.UpdateCategory;

namespace WebUtil.Lyrics.Application.Albums.Command.UpdateAlbum
{
	public record UpdateAlbumCommand
	(
		string AlbumCode,
		string AlbumName,
		DateTime Released,
		int Status
	) : IRequest<UpdateAlbumResult>;
}
