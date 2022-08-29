using Apache.Ignite.Core.Client;
using Liquid.Cache;
using Liquid.Core.Utils;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Liquid.DistributedCache.Ignite
{
    public class IgniteDistributedCache : ILiquidCache
    {
        private readonly IIgniteClient _client;

        public IgniteDistributedCache(IIgniteClientFactory clientFactory)
        {
            _client = clientFactory?.GetClient() ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public byte[] Get(string key)
        {
            return _client.GetCache<string, string>(key).ToBytes();
        }

        public async Task<byte[]> GetAsync(string key, CancellationToken token = default)
        {
            return _client.GetCache<string, string>(key).ToBytes();
        }

        public void Refresh(string key)
        {
            throw new NotImplementedException();
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
