using Mapster;
using MapsterMapper;
using WebUtil.Lyrics.Application.Songs.Queries.GetSongPagedList;
using WebUtil.Lyrics.Contracts.SongContract.GetSongPagedList;

namespace WebUtil.Lyrics.Api.Mapping
{
    public class SongPagedListMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetSongPagedListResult, GetSongPagedListResponse>()
                .Map(dest => dest.Songs, src => src.Songs);
        }
    }
}
