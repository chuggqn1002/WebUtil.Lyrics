﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public class NotProfileExisted : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "Profile does not exists.";
    }
}
