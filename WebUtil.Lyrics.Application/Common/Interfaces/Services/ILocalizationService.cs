using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Services
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key, string culture);
    }
}
