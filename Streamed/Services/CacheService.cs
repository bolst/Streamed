using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Streamed.Services;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;
    private CancellationTokenSource _resetCacheToken = new();

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public async Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> factory, TimeSpan cacheDuration)
    {
        if (!_memoryCache.TryGetValue(cacheKey, out T cacheEntry))
        {
            cacheEntry = await factory();

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheDuration
            };
            cacheOptions.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));

            _memoryCache.Set(cacheKey, cacheEntry, cacheOptions);
        }

        return cacheEntry;
    }

    public void Clear()
    {
        // expire every item in cache
        _resetCacheToken.Cancel();

        // create new cancellation token
        _resetCacheToken.Dispose();
        _resetCacheToken = new CancellationTokenSource();
    }
}
