
namespace WebUtil.Lyrics.Contracts.SongContract.GetSongById
{
    public record GetSongByIdResponse
    (
        Guid Suid,
        string Song_code,
        string Title,
        string Author,
        string Album_code,
        string Album_name,
        string Description,
        DateTime Released,
        List<Song_Line> Song_Lines
    );

    public record Song_Line(
        string song_text,
        int line_order,
        int para
        );
}
