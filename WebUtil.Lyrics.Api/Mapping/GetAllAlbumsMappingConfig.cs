using Mapster;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;
using WebUtil.Lyrics.Contracts.Album.GetAllAlbum;
using WebUtil.Lyrics.Contracts.Tag.GetAllTags;

namespace WebUtil.Lyrics.Api.Mapping
{
	public class GetAllAlbumsMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<GetAllAlbumsResult, GetAllAlbumsResponse>()
				.Map(dest => dest.AlbumList, src => src.albumList);
		}
	}
}
