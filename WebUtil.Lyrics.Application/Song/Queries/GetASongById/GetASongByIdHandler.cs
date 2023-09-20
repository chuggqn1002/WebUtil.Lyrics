using FluentValidation;
using MediatR;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetASongById
{
    public class GetASongByIdHandler : IRequestHandler<GetASongByIdQuery, GetASongByIdResult>
    {

        private readonly ISongRepository _songRepository;

        public GetASongByIdHandler(ISongRepository songRepository)
        {
            
            _songRepository = songRepository;
        }

        public async Task<GetASongByIdResult> Handle(GetASongByIdQuery request, CancellationToken cancellationToken)
        {


            var song = _songRepository.GetByGuidAsync(request.Suid);
            if (song == null)
            {
                throw new ArgumentNullException("Song is null");
            }

            return new GetASongByIdResult(song.Result);
        }
    }
}
