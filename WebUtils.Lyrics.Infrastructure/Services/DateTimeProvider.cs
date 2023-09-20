using System;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
   
    public DateTime UtcNow => DateTime.UtcNow;

}

