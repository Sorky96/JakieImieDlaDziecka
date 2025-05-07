using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Caching;
using System.Threading;
using System.Threading.Tasks;


namespace DataAccess.Providers
{

    public class AsyncMemoryCacheProvider : IAsyncCacheProvider
    {
        private readonly IMemoryCache _memoryCache;

        public AsyncMemoryCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<(bool, object)> TryGetAsync(string key, Context context, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(key, out var value))
            {
                return Task.FromResult((true, value));
            }
            return Task.FromResult((false, (object)null));
        }

        public Task PutAsync(string key, object value, Ttl ttl, Context context, CancellationToken cancellationToken)
        {
            _memoryCache.Set(key, value, ttl.Timespan);
            return Task.CompletedTask;
        }

        public Task<(bool, object)> GetAsync(string key, Context context, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(key, out var value))
            {
                return Task.FromResult((true, value));
            }
            return Task.FromResult((false, (object)null));
        }

        public Task RemoveAsync(string key, Context context, CancellationToken cancellationToken)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }

        public Task<(bool, object?)> TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext)
        {
            if (_memoryCache.TryGetValue(key, out var value))
            {
                return Task.FromResult<(bool, object?)>((true, value));
            }
            return Task.FromResult<(bool, object?)>((false, null));
        }

        public Task PutAsync(string key, object? value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext)
        {
            _memoryCache.Set(key, value, ttl.Timespan);
            return Task.CompletedTask;
        }
    }
}
