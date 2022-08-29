using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.Cache.DistributedCache
{
    ///<inheritdoc/>
    public class LiquidDistributedCache : ILiquidCache
    {
        private readonly IDistributedCache _distributedCache;

        /// <summary>
        /// Initialize a new instance of <see cref="LiquidDistributedCache"/>
        /// </summary>
        /// <param name="distributedCache"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LiquidDistributedCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        ///<inheritdoc/>
        public byte[] Get(string key)
        {
            return _distributedCache.Get(key);
        }

        ///<inheritdoc/>
        public Task<byte[]> GetAsync(string key, CancellationToken token = default)
        {
            return _distributedCache.GetAsync(key, token);
        }

        ///<inheritdoc/>
        public void Refresh(string key)
        {
            _distributedCache.Refresh(key);
        }

        ///<inheritdoc/>
        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            return _distributedCache.RefreshAsync(key, token);
        }

        ///<inheritdoc/>
        public void Remove(string key)
        {
            _distributedCache?.Remove(key);
        }

        ///<inheritdoc/>
        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            return _distributedCache.RemoveAsync(key, token);
        }

        ///<inheritdoc/>
        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            _distributedCache.Set(key, value, options);
        }

        ///<inheritdoc/>
        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            return _distributedCache.SetAsync(key, value, options, token);
        }
    }
}
