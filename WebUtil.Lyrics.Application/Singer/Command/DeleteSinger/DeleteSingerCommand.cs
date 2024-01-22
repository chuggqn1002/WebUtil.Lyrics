using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Singers.Command.DeleteSinger
{
	public record DeleteSingerCommand(string singercode):IRequest<DeleteSingerResult>;
}
