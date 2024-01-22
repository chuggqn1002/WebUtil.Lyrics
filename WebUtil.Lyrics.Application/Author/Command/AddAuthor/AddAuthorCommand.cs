using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Categories.Commands.AddCategory;

namespace WebUtil.Lyrics.Application.Authors.Command.AddAuthor
{
	public record AddAuthorCommand
	(
		string AuthorCode,
		string AuthorName,
		string Bio,
		string Avatar,
		int Status
	) : IRequest<AddAuthorResult>;
}
