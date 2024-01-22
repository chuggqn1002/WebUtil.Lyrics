using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Singers.Command.UpdateSinger
{
	public record UpdateSingerCommand
	(string SingerCode,
		string SingerName,
		string Bio,
		string Avatar,
		int Status) :IRequest<UpdateSingerResult>;
}
