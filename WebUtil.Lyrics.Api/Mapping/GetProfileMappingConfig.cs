using Mapster;
using WebUtil.Lyrics.Application.UserProfile.Queries.GetProfile;
using WebUtil.Lyrics.Contracts.UserProfile.GetProfile;

namespace WebUtil.Lyrics.Api.Mapping
{
    public class GetProfileMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetProfileResult, GetProfileResponse>()
           .Map(dest => dest.User, src => src.profile)
           .Map(dest => dest.User.Uuid, src => src.profile.Uuid)
           .Map(dest => dest.User.Email, src => src.Email)
           .Map(dest => dest.User.Username, src => src.Username);
        }
    }
}
