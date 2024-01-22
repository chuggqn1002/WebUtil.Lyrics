using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Singer.GetAllSinger
{
	public record GetAllSingerResponse(IEnumerable<SingerRecord> SingerList);
	public record SingerRecord(
		int SingerId,
		string SingerCode,
		string SingerName,
		string Bio,
		string Avatar,
		int Status);
}
