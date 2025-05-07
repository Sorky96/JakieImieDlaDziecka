using DataAccess.Interfaces;
using DataAccess.Providers;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Polly;
using StatisticsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatisticsProcessor.Services
{
    public class NameService : INameService
    {
        private readonly INameRepository _nameRepository;
        private readonly AsyncPolicy<IEnumerable<NameRecord>> _cachePolicy;

        public NameService(IMemoryCache memoryCache, INameRepository nameRepository)
        {
            _nameRepository = nameRepository;

            var memoryCacheProvider = new AsyncMemoryCacheProvider(memoryCache);
            _cachePolicy = Policy.CacheAsync<IEnumerable<NameRecord>>(memoryCacheProvider, TimeSpan.FromMinutes(10));
        }

        public async Task<IEnumerable<NameRecord>> GetNamesAsync(int year)
        {
            string cacheKey = $"names-{year}";

            return await _cachePolicy.ExecuteAsync(
                async (context) => await _nameRepository.GetNamesByYearAsync(year),
                new Context(cacheKey)
            );
        }

        public async Task<IEnumerable<NameRecord>> GetTopNamesAsync(int year, int top)
        {
            string cacheKey = $"names-{year}-{top}";

            return await _cachePolicy.ExecuteAsync(
                async (context) => await _nameRepository.GetTopNamesByYearAsync(year, top),
                new Context(cacheKey)
            );
        }
    }
}
