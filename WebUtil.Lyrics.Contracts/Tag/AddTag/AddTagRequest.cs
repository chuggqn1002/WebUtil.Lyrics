using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Tag.AddTag
{
	public record AddTagRequest
	(
		string TagCode,
		string TagName,
		int Status
	);
}
