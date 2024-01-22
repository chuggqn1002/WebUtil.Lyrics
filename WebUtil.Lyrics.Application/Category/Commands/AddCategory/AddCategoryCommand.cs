using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Tag.Commands.AddTag;

namespace WebUtil.Lyrics.Application.Categories.Commands.AddCategory
{
	public record AddCategoryCommand
	(
		string CategoryCode,
		string CategoryName,
		int Status
	) : IRequest<AddCategoryResult>;
}
