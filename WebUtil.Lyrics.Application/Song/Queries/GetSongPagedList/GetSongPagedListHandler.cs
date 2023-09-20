using MediatR;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetSongPagedList
{
    public class GetSongPagedListHandler : IRequestHandler<GetSongPagedListQuery, GetSongPagedListResult>
    {
        ISongRepository _songRepository;

        public GetSongPagedListHandler(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<GetSongPagedListResult> Handle(GetSongPagedListQuery request, CancellationToken cancellationToken)
        {
            int pageNum = request.pageNum;
            int pageSize = (request.pageSize != 0)?request.pageSize:30;
            var songList = await _songRepository.GetSongPagedList(pageNum, pageSize);
            if (songList == null)
            {
                throw new ArgumentException("not song list with page:" + pageNum.ToString() 
                    + " - pageSize:" + pageSize.ToString());
            }
            int totalRecord = songList.Count();

            return new GetSongPagedListResult(songList);              
        }
    }
}
