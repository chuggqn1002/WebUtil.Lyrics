using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Tag.Commands.DeleteTag
{
	public record DeleteTagCommand(string tagcode):IRequest<DeleteTagResult>;
}
