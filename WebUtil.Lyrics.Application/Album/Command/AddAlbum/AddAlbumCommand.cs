using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Categories.Commands.AddCategory;

namespace WebUtil.Lyrics.Application.Albums.Command.AddAlbum
{
	public record AddAlbumCommand
	(
		string AlbumCode,
		string AlbumName,
		DateTime Released,
		int Status
	) : IRequest<AddAlbumResult>;
}
