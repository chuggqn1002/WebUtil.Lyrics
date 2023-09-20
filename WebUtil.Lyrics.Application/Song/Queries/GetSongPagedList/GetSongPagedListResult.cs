
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetSongPagedList
{
    public record GetSongPagedListResult(
        IEnumerable<Song> Songs);
    
}
