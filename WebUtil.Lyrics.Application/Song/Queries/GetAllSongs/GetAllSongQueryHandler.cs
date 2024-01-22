using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Songs.Queries.GetAllSongs;

namespace WebUtil.Lyrics.Application.Songs.Queries.GetAllSongs
{
	public class GetAllSongQueryHandler : IRequestHandler<GetAllSongsQuery, GetAllSongsResult>
	{
		private readonly ISongRepository _songRepository;

		public GetAllSongQueryHandler(ISongRepository songRepository)
		{
			_songRepository = songRepository;
		}

		public async Task<GetAllSongsResult> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
		{
			var result = await _songRepository.GetAllAsync();
			return new GetAllSongsResult(result);
		}
	}
}
