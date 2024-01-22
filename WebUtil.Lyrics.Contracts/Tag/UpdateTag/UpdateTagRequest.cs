using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Contracts.Tag.UpdateTag
{
	public record UpdateTagRequest
	(
		string TagCode,
		string TagName,
		int Status
	);
}
