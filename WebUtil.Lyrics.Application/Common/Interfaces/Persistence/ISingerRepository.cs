using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
	public interface ISingerRepository : IGenericRepository<Singer>
	{
		Task<int> DeleteByCodeAsync(string code);
		Task<Domain.Entities.Singer?> GetByCodeAsync(string code);
	}
}
