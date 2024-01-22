using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
    public interface ISongRepository : IGenericRepository<Domain.Entities.Song>
    {

        public Task<IEnumerable<Song_Line>> GetSongLinesBySuid(Guid Suid);

        public Task<IEnumerable<Domain.Entities.Song>> GetSongPagedList(int  pageNum, int pageSize);

        public Task<IEnumerable<Domain.Entities.Song>> SearchAsync(string query);
	}
}
