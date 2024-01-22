using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Album.Query.GetAllAlbums
{
	public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, GetAllAlbumsResult>
	{
		private readonly IAlbumRepository _albumRepository;

		public GetAllAlbumsQueryHandler(IAlbumRepository albumRepository)
		{
			_albumRepository = albumRepository;
		}

		public async Task<GetAllAlbumsResult> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
		{
			var queryResult = await _albumRepository.GetAllAsync();
			if (queryResult == null)
			{
				throw new ArgumentNullException("Albums is null");
			}
			return new GetAllAlbumsResult(queryResult);
		}
	}
}
