using Mapster;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Songs.Queries.SearchSong;
using WebUtil.Lyrics.Contracts.Album.GetAllAlbum;
using WebUtil.Lyrics.Contracts.SongContract.SearchSong;

namespace WebUtil.Lyrics.Api.Mapping
{
	public class SearchSongMappingConfig:IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<SearchSongResult, SearchSongResponse>()
				.Map(dest => dest.songs, src => src.songs);
		}
	}
}
