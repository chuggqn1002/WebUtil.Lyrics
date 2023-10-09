using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public class InvalidRegisterData : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Created;

        public string ErrorMessage => "Email or Username is not valid.";
    }
}
