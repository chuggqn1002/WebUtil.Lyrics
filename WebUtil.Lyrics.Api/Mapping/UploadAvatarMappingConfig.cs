using Mapster;
using WebUtil.Lyrics.Application.Profile.Commands.UploadAvatar;
using WebUtil.Lyrics.Contracts.UserProfile.UploadAvatar;

namespace WebUtil.Lyrics.Api.Mapping
{
    public class UploadAvatarMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UploadAvatarCommandResult, UploadAvatarResponse>()
                .Map(dest => dest.filePath, src => src.filePath);
                

        }
    }
}
