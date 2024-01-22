using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Tag.Commands.UpdateTag
{
	public record UpdateTagCommand
	(
		string TagCode,
		string TagName,
		int Status
	):IRequest<UpdateTagResult>;
}
