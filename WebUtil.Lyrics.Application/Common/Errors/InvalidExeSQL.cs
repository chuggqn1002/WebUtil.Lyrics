using System.Net;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public class InvalidExeSQL : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "Execution Sql failed.";
    }
}
