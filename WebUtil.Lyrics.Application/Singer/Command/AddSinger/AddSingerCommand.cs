using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Authors.Command.AddAuthor;

namespace WebUtil.Lyrics.Application.Singers.Command.AddSinger
{
	public record AddSingerCommand
	(
		string SingerCode,
		string SingerName,
		string Bio,
		string Avatar,
		int Status
	) : IRequest<AddSingerResult>;
}
