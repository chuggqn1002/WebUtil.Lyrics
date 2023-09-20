using Newtonsoft.Json;
using StackExchange.Redis;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;

namespace WebUtil.Lyrics.Infrastructure.Services
{
    public class CacheManagerService : ICacheManager
    {
        IConnectionMultiplexer _connectionMultiplexer;

        public CacheManagerService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallback, TimeSpan cacheDuration)
        {
            var cacheDB = _connectionMultiplexer.GetDatabase();

            var cacheItem = await cacheDB.StringGetAsync(cacheKey);
            if (!cacheItem.IsNull)
            {
                return JsonConvert.DeserializeObject<T>(cacheItem);
            }

            var item = await getItemCallback();

            if (item != null)
            {
                await cacheDB.StringSetAsync(cacheKey, JsonConvert.SerializeObject(item), cacheDuration);

            }

            return item;
        }
    }
}
