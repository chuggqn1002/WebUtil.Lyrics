using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
	public interface ISongTagRepository : IGenericRepository<Song_Tag>
	{
		Task<IEnumerable<Song_Tag>> GetAllBySuidAsync(string suid);
	}
}
