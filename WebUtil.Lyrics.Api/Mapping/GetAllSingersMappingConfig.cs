using Mapster;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Singers.Query.GetAllSingers;
using WebUtil.Lyrics.Contracts.Album.GetAllAlbum;
using WebUtil.Lyrics.Contracts.Singer.GetAllSinger;

namespace WebUtil.Lyrics.Api.Mapping
{
	public class GetAllSingersMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<GetAllSingersResut, GetAllSingerResponse>()
				.Map(dest => dest.SingerList, src => src.singerList);
		}
	}
}
