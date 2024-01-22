using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Authors.Query.GetAllAuthor
{
	public record GetAllAuthorsResult
	(
		IEnumerable<Domain.Entities.Author> authorList
	);
}
