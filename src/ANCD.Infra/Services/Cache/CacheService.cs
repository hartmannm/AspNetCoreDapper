using ANCD.Domain.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ANCD.Infra.Services.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private static JsonSerializerOptions _serializerOptions;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _serializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
        }

        public async Task<T> GetFromCacheAsync<T>(string key) where T : class
        {
            var maybe = await _distributedCache.GetAsync(NormalizeKey(key));

            if (maybe is not null)
                return JsonSerializer.Deserialize<T>(maybe);

            return null;
        }

        public async Task SetCacheAsync(string key, object value, TimeSpan expirationFromNow)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationFromNow
            };

            var serializedData = JsonSerializer.Serialize(value, _serializerOptions);
            await _distributedCache.SetStringAsync(NormalizeKey(key), serializedData, cacheOptions);
        }

        public async Task RemoveFromCache(string key) => await _distributedCache.RemoveAsync(NormalizeKey(key));

        private string NormalizeKey(string key) => $"-Cache-{key}";
    }
}
