using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Albums.Command.DeleteAlbum;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Authors.Command.DeleteAuthor
{
	public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeleteAuthorResult>
	{
		private readonly IAuthorRepository _authorRepository;
		private readonly ISongRepository _songRepository;

		public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, ISongRepository songRepository)
		{
			_authorRepository = authorRepository;
			_songRepository = songRepository;
		}

		public async Task<DeleteAuthorResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
		{
			var c = await _authorRepository.DeleteByCodeAsync(request.authorcode);
			IEnumerable<Domain.Entities.Song> songs = ((List<Domain.Entities.Song>)await _songRepository.GetAllAsync()).Where(song => song.Author == request.authorcode);
			foreach (var song in songs)
			{
				song.Author = null;
				var r = await _songRepository.UpdateAsync(song);
			}
			return new DeleteAuthorResult(c);
		}
	}
}
