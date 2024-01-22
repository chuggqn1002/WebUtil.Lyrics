using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Authors.Command.DeleteAuthor
{
	public record DeleteAuthorResult(int count);
}
