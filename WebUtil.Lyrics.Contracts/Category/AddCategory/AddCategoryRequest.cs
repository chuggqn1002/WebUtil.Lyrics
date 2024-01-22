using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Category.AddCategory
{
	public record AddCategoryRequest
	(
		string CategoryCode,
		string CategoryName,
		int Status
	);
}
