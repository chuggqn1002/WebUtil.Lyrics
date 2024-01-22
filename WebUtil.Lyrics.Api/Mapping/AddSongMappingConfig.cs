using Mapster;
using WebUtil.Lyrics.Application.Authentication.Common;
using WebUtil.Lyrics.Application.Songs.Commands.AddSong;
using WebUtil.Lyrics.Contracts.Authentication;
using WebUtil.Lyrics.Contracts.SongContract.AddSong;

namespace WebUtil.Lyrics.Api.Mapping
{
	public class AddSongMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<AddSongRequest, AddSongCommand>()
				.Map(dest => dest.Album, src => src.Album)
				.Map(dest => dest.Author, src => src.Author)
				.Map(dest => dest.Description, src => src.Description)
				.Map(dest => dest.Status, src => src.Status)
				.Map(dest => dest.Singer, src => src.Singer)
				.Map(dest => dest.SongCode, src => src.SongCode)
				.Map(dest => dest.Released, src => src.Released)
				.Map(dest => dest.Song_Lines, src => src.Song_Lines)
				.Map(dest => dest.Title, src => src.Title)
				.Map(dest => dest.YtbCode, src => src.YtbCode)
				.Map(dest => dest.VideoLink, src => src.VideoLink)
				.Map(dest => dest.ImgUrl, src => src.ImgUrl);





		}
	}
}
