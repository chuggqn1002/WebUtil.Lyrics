using WebUtil.Lyrics.Domain.Entities;


namespace WebUtil.Lyrics.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

