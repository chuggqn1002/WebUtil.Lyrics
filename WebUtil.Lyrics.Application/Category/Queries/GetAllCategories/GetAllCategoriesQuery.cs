using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories;

namespace WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories
{
	public record GetAllCategoriesQuery:IRequest<GetAllCategoriesResult>;
}
