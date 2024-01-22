using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Author.GetAllAuthor
{
	public record GetAllAuthorsResponse(IEnumerable<AuthorRecord> AuthorList);
	public record AuthorRecord(
		int AuthorId,
		string AuthorCode,
		string AuthorName,
		string Bio,
		string Avatar,
		int Status);
}
