using Mapster;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;
using WebUtil.Lyrics.Contracts.Tag.GetAllTags;

namespace WebUtil.Lyrics.Api.Mapping
{
    public class GetAllTagsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetAllTagsResult, GetAllTagsResponse>()
                .Map(dest => dest.TagList, src => src.tagList);
        }
    }
}
