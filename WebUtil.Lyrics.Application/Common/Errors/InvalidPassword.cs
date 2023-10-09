
namespace WebUtil.Lyrics.Application.Common.Errors;

public class Invalid_Account_Password : InvalidBadRequest
{

    public override string ErrorMessage => "Invalid Password or Username combination.";
}

