using Mapster;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Authors.Query.GetAllAuthor;
using WebUtil.Lyrics.Contracts.Album.GetAllAlbum;
using WebUtil.Lyrics.Contracts.Author.GetAllAuthor;

namespace WebUtil.Lyrics.Api.Mapping
{
	public class GetAllAuthorsMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<GetAllAuthorsResult, GetAllAuthorsResponse>()
				.Map(dest => dest.AuthorList, src => src.authorList);
		}
	}
}
