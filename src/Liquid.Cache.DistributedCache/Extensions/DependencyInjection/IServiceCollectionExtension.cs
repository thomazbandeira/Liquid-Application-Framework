using Alachisoft.NCache.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Liquid.Cache.DistributedCache.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddLiquidMemoryDistributedCache(this IServiceCollection services, IConfiguration configuration,
            string section, bool withTelemetry)
        {
            services.Configure<MemoryDistributedCacheOptions>(options => configuration.GetSection(section));
            services.AddDistributedMemoryCache();

            return AddLiquidDistributedCache(services, withTelemetry);
        }

        public static IServiceCollection AddLiquidSqlServerDistributedCache(this IServiceCollection services, IConfiguration configuration,
            string section, bool withTelemetry)
        {
            services.AddDistributedSqlServerCache(options => configuration.GetSection(section));

            return AddLiquidDistributedCache(services, withTelemetry);
        }

        public static IServiceCollection AddLiquidRedisDistributedCache(this IServiceCollection services, IConfiguration configuration,
            string section, bool withTelemetry)
        {
            services.AddStackExchangeRedisCache(options => configuration.GetSection(section));

            return AddLiquidDistributedCache(services, withTelemetry);
        }

        public static IServiceCollection AddLiquidNCacheDistributedCache(this IServiceCollection services, IConfiguration configuration,
            string section, bool withTelemetry)
        {
            services.AddNCacheDistributedCache(options => configuration.GetSection(section));

            return AddLiquidDistributedCache(services, withTelemetry);
        }

        private static IServiceCollection AddLiquidDistributedCache(IServiceCollection services, bool withTelemetry)
        {
            if (withTelemetry)
            {
                services.AddScoped<LiquidDistributedCache>();
                //services.AddScopedLiquidTelemetry<ILiquidCache, LiquidDistributedCache>();
            }
            else
                services.AddScoped<ILiquidCache, LiquidDistributedCache>();

            return services;
        }
    }
}
