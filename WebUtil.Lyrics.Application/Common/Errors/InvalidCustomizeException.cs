using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public class InvalidCustomizeException : Exception, IExceptionService
    {
        
        public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public string ErrorMessage => "an server error occurred";
    }
}
