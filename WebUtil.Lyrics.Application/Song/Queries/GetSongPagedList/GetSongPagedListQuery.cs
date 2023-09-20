using MediatR;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetSongPagedList
{
    public record GetSongPagedListQuery(
        int pageNum,
        int pageSize
        ):IRequest<GetSongPagedListResult>;
}
