using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Albums.Command.AddAlbum;
using WebUtil.Lyrics.Application.Categories.Commands.AddCategory;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Albums.Command.AddAlbum
{
	public record AddAlbumCommandHandler : IRequestHandler<AddAlbumCommand, AddAlbumResult>
	{
		private readonly IAlbumRepository _albumRepository;

		public AddAlbumCommandHandler(IAlbumRepository albumRepository)
		{
			_albumRepository = albumRepository;
		}

		public async Task<AddAlbumResult> Handle(AddAlbumCommand request, CancellationToken cancellationToken)
		{
			List<Domain.Entities.Album> albums = (List<Domain.Entities.Album>)await _albumRepository.GetAllAsync();
			if (albums.Any(album => album.AlbumCode == request.AlbumCode))
			{
				throw new Exception();
			}
			Domain.Entities.Album album = new Domain.Entities.Album()
			{
				AlbumCode = request.AlbumCode,
				AlbumName = request.AlbumName,
				Released = request.Released,
				Status = request.Status
			};
			int id = await _albumRepository.AddAsync(album);
			//await _cacheManager.DeleteKey("Tag:GetAllAsync");
			return new AddAlbumResult(id);
		}
	}
}
