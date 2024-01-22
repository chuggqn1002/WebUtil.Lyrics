using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Singers.Query.GetAllSingers
{
	public record GetAllSingersResut(IEnumerable<Domain.Entities.Singer> singerList);
	
}
