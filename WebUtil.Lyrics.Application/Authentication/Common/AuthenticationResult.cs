
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Authentication.Common;

public record AuthenticationResult(User user, string Token);


