using BC = BCrypt.Net;
using WebUtil.Lyrics.Application.Authentication.Common;
using WebUtil.Lyrics.Application.Common.Errors;
using WebUtil.Lyrics.Application.Common.Interfaces;
using MediatR;
using WebUtil.Lyrics.Domain.Entities;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Authentication.Queries.Login;


public class LoginQueryHandler :
    IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new InvalidUser();
        }


        if (!BC.BCrypt.Verify(query.Password, user.Password))
        {
            throw new Invalid_Account_Password();
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}