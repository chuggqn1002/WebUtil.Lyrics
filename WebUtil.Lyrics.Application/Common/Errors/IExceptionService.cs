﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Errors
{
    public interface IExceptionService
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
