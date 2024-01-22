using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtil.Lyrics.Application.Common.Interfaces.Services
{
    public interface ICacheManager
    {
        Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallback, TimeSpan TimeDuration);
        Task DeleteKey(string key);

	}
}
