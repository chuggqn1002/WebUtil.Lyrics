using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Albums.Command.DeleteAlbum;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Album.Command.DeleteAlbum
{
	public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, DeleteAlbumResult>
	{
		private readonly IAlbumRepository _albumRepository;
		private readonly ISongRepository _songRepository;

		public DeleteAlbumCommandHandler(IAlbumRepository albumRepository, ISongRepository songRepository)
		{
			_albumRepository = albumRepository;
			_songRepository = songRepository;
		}

		public async Task<DeleteAlbumResult> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
		{
			var c = await _albumRepository.DeleteByCodeAsync(request.albumcode);
			IEnumerable<Domain.Entities.Song> songs = ((List<Domain.Entities.Song>)await _songRepository.GetAllAsync()).Where(song => song.Album == request.albumcode);
			foreach (var song in songs)
			{
				song.Album = null;
				var r = await _songRepository.UpdateAsync(song);
			}
			return new DeleteAlbumResult(c);
		}
	}
}
