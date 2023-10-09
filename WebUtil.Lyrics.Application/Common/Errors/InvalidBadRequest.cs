using System.Net;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public class InvalidBadRequest : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public virtual string ErrorMessage => "Invalid Bad request!";
    }
}
