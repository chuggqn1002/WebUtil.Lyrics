using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
	public interface IAuthorRepository : IGenericRepository<Domain.Entities.Author>
	{
		Task<int> DeleteByCodeAsync(string code);
		Task<Domain.Entities.Author?> GetByCodeAsync(string code);
	}
}
