using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
	public interface ICategoryRepository : IGenericRepository<Domain.Entities.Category>
	{
		Task<int> DeleteByCodeAsync(string code);
		Task<Domain.Entities.Category?> GetByCodeAsync(string code);

	}
}
