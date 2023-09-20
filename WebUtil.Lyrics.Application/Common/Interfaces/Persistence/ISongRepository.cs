using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Persistence
{
    public interface ISongRepository : IGenericRepository<Song>
    {

        public Task<IEnumerable<Song_Line>> GetSongLinesBySuid(Guid Suid);

        public Task<IEnumerable<Song>> GetSongPagedList(int  pageNum, int pageSize);
      
    }
}
