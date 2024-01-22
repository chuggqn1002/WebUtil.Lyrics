using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Songs.Queries.SearchSong
{
	public class SearchSongQueryHandler : IRequestHandler<SearchSongQuery, SearchSongResult>
	{
		private readonly ISongRepository _songRepository;

		public SearchSongQueryHandler(ISongRepository songRepository)
		{
			_songRepository = songRepository;
		}

		public async Task<SearchSongResult> Handle(SearchSongQuery request, CancellationToken cancellationToken)
		{
			var songs = await _songRepository.SearchAsync(request.query);
			return new SearchSongResult(songs);
		}
	}
}
