using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Authors.Command.DeleteAuthor;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Singers.Command.DeleteSinger
{
	public class DeleteSingerCommandHandler : IRequestHandler<DeleteSingerCommand, DeleteSingerResult>
	{
		private readonly ISingerRepository _repository;
		private readonly ISongRepository _songRepository;

		public DeleteSingerCommandHandler(ISingerRepository repository, ISongRepository songRepository)
		{
			_repository = repository;
			_songRepository = songRepository;
		}

		public async Task<DeleteSingerResult> Handle(DeleteSingerCommand request, CancellationToken cancellationToken)
		{
			var c = await _repository.DeleteByCodeAsync(request.singercode);
			IEnumerable<Domain.Entities.Song> songs = ((List<Domain.Entities.Song>)await _songRepository.GetAllAsync()).Where(song => song.Singer == request.singercode);
			foreach (var song in songs)
			{
				song.Singer = null;
				var r = await _songRepository.UpdateAsync(song);
			}
			return new DeleteSingerResult(c);
		}
	}
}
