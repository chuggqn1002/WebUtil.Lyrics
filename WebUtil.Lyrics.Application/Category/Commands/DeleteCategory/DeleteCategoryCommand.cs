using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Tag.Commands.DeleteTag;

namespace WebUtil.Lyrics.Application.Categories.Commands.DeleteCategory
{
	public record DeleteCategoryCommand(string categorycode) : IRequest<DeleteCategoryResult>;
}
