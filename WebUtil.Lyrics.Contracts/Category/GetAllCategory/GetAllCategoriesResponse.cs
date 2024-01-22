using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Category.GetAllCategory
{
	public record GetAllCategoriesResponse(IEnumerable<CategoryRecord> CategoryList);
	public record CategoryRecord(
		int CategoryId,
		string CategoryCode,
		string CategoryName,
		int Status);
}
