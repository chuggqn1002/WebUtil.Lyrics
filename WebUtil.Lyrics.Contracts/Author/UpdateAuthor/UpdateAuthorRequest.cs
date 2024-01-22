using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Author.UpdateAuthor
{
	public record UpdateAuthorRequest
	(
		string AuthorCode,
		string AuthorName,
		string Bio,
		string Avatar,
		int Status);
}
