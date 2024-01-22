using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Categories.Commands.UpdateCategory;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Albums.Command.UpdateAlbum
{
	public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, UpdateAlbumResult>
	{
		private readonly IAlbumRepository _albumRepository;

		public UpdateAlbumCommandHandler(IAlbumRepository albumRepository)
		{
			_albumRepository = albumRepository;
		}

		public async Task<UpdateAlbumResult> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Album? a = await _albumRepository.GetByCodeAsync(request.AlbumCode);
			if (a == null)
			{
				throw new Exception("invalid AlbumCode");
			}
			Domain.Entities.Album album = new Domain.Entities.Album()
			{
				AlbumCode = request.AlbumCode,
				AlbumName = request.AlbumName,
				Released = request.Released,
				Status = request.Status
			};
			int r = await _albumRepository.UpdateAsync(album);
			return new UpdateAlbumResult(r);
		}
	}
}
