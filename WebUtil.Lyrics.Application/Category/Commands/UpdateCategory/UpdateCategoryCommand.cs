using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Tag.Commands.UpdateTag;

namespace WebUtil.Lyrics.Application.Categories.Commands.UpdateCategory
{
	public record UpdateCategoryCommand
	(
		string CategoryCode,
		string CategoryName,
		int Status
	) : IRequest<UpdateCategoryResult>;
}
