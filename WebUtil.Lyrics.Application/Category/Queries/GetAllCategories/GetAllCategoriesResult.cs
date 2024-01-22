using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories
{
	public record GetAllCategoriesResult(IEnumerable<Domain.Entities.Category> categoryList);
}
