
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
    public interface ITagRepository : IGenericRepository<Domain.Entities.Tag>
    {
        Task<int> DeleteByCodeAsync(string code);
		Task<Domain.Entities.Tag?> GetByCodeAsync(string code);

	}
}
