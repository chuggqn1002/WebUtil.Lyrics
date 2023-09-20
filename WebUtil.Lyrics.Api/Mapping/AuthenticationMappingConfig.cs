using System;
using WebUtil.Lyrics.Application.Authentication.Common;
using WebUtil.Lyrics.Contracts.Authentication;
using Mapster;

namespace WebUtil.Lyrics.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.user)
            .Map(dest => dest.Uuid, src => src.user.Uuid)
            .Map(dest => dest.Userid, src => src.user.Userid);
            
    }
}


