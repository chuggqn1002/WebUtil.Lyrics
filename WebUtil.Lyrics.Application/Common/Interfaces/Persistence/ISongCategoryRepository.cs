using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
	public interface ISongCategoryRepository : IGenericRepository<Song_Category>
	{
		Task<IEnumerable<Song_Category>> GetAllBySuidAsync(string suid);
	}
}
