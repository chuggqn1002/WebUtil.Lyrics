using System.Net;

namespace WebUtil.Lyrics.Application.Common.Errors;

public class DuplicateEmailException : Exception, IExceptionService
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Duplicated email is not valid.";
}