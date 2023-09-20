using MediatR;
using WebUtil.Lyrics.Application.Authentication.Common;

namespace WebUtil.Lyrics.Application.Services.Commands.Register;

public record RegisterCommand(
    string Username,
    string Email,
    string Password,
    string Role): IRequest<AuthenticationResult>;

