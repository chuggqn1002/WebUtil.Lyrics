using WebUtil.Lyrics.Application.Authentication.Common;
using MediatR;

namespace WebUtil.Lyrics.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>;

