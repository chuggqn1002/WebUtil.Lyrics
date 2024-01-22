using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Singer.UpdateSinger
{
	public record UpdateSingerRequest
	(
		string SingerCode,
		string SingerName,
		string Bio,
		string Avatar,
		int Status);
}
