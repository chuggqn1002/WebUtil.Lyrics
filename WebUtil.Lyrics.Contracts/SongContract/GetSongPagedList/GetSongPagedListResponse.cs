

namespace WebUtil.Lyrics.Contracts.SongContract.GetSongPagedList
{
    public record GetSongPagedListResponse(IEnumerable<SongRecord> Songs);


    public record SongRecord
   (
        int Sid,
        Guid Suid,
        string SongCode,
        string? Title,
        string? Album,
        string? AlbumCode,
        string? AlbumName,
        string? Author,
        string? AuthorCode,
        string? AuthorName,
        string? Singer,
        string? SingerCode,
        string? SingerName,
        string? ImgUrl,
        string? YtbCode,
        string? VideoLink,
        string? Description,
        DateTime Released,
        int Status
//        IEnumerable<SongTag> SongTags
    );

    //public record SongTag (
    //    string TagCode,
    //    string TagName
    //    );
    
}
