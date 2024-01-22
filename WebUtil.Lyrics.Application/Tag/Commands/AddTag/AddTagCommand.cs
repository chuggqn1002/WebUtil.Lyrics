using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Tag.Commands.AddTag
{
	public record AddTagCommand
	(
		string TagCode,
		string TagName,
		int Status
	):IRequest<AddTagResult>;
}
