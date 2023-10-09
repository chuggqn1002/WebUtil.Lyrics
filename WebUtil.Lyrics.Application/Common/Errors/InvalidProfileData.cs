using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public class InvalidProfileData : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Created;

        public string ErrorMessage => "Profile Data is not valid.";
    }
}
