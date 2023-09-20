using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using WebUtil.Lyrics.Application.Common.Interfaces;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);



        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Uuid.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

        };
        claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        claims.Add(new Claim("UserId", user.Userid.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, user.Username));
        

        var securityToken = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            expires:_dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken); 
    }
}

