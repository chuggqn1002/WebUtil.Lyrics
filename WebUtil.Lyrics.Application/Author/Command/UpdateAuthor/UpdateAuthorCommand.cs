using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Albums.Command.UpdateAlbum;

namespace WebUtil.Lyrics.Application.Authors.Command.UpdateAuthor
{
	public record UpdateAuthorCommand
	(
		string AuthorCode,
		string AuthorName,
		string Bio,
		string Avatar,
		int Status
	) : IRequest<UpdateAuthorResult>;
}
