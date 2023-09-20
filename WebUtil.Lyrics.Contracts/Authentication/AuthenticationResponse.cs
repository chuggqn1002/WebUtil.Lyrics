
namespace WebUtil.Lyrics.Contracts.Authentication;
public record AuthenticationResponse(
		int Userid,
		Guid Uuid,
		string Email,
		int Role,
		string Token);