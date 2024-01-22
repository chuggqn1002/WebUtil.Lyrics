using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Songs.Commands.AddSong
{
	public class AddSongCommandHandler : IRequestHandler<AddSongCommand, AddSongResult>
	{
		private readonly ISongLineRepository songLineRepository;
		private readonly ISongRepository songRepository;
		public AddSongCommandHandler(ISongLineRepository songLineRepository, ISongRepository songRepository)
		{
			this.songLineRepository = songLineRepository;
			this.songRepository = songRepository;
		}

		public async Task<AddSongResult> Handle(AddSongCommand request, CancellationToken cancellationToken)
		{
			Guid suid = Guid.NewGuid();
			Song song = new Song()
			{
				Suid = suid,
				SongCode = request.SongCode,
				Title = request.Title,
				Album = request.Album,
				Author = request.Author,
				Singer = request.Singer,
				ImgUrl = request.ImgUrl,
				YtbCode = request.YtbCode,
				VideoLink = request.VideoLink,
				Description = request.Description,
				Released = request.Released,
				Status = request.Status
			};
			
			
			
			int id = await songRepository.AddAsync(song);
			int i = 1;
			request.Song_Lines.ToList().ForEach(async (sl) => {
				Song_Line song_Line = new Song_Line()
				{
					Suid = suid,
					Song_Text = sl,
					Line_Order = i,
					Param = 0
				}; i++;
				var x = await songLineRepository.AddAsync(song_Line);


			});
			return new AddSongResult(id);

		}
	}
}
