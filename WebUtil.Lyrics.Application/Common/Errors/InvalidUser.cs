
namespace WebUtil.Lyrics.Application.Common.Errors;

public class InvalidUser : InvalidBadRequest
{
    public override  string ErrorMessage => "Invalid user input data!";
}

