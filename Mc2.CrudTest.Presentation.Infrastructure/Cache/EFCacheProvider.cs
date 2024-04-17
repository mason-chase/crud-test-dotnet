
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.Extensions.DependencyInjection;


namespace Mc2.CrudTest.Presentation.Infrastructure.Cache
{
    /// <summary>
    /// EF Second Level Cache
    /// </summary>
    public static class EFCacheProvider
    {
        /// <summary>
        /// Add EF Second Level Cache By EasyCaching
        /// In-Memory Or Redis
        /// </summary>
        /// <param name="services"></param>
        public static void AddEFCacheProvider(this IServiceCollection services, string providerName)
        {
            services.AddEFSecondLevelCache(options =>
               options.UseEasyCachingCoreProvider(providerName).DisableLogging(true).UseCacheKeyPrefix("MC2_")
           // Please use the `CacheManager.Core` or `EasyCaching.Redis` for the Redis cache provider.
           );
        }
        /// <summary>
        /// Add EF Second Level Cache By In-Memory
        /// </summary>
        /// <param name="services"></param>
        public static void AddInMemoryEFCacheProvider(this IServiceCollection services)
        {
            services.AddEFSecondLevelCache(options =>
               options.UseMemoryCacheProvider().DisableLogging(true).UseCacheKeyPrefix("MC2_")
           // Please use the `CacheManager.Core` or `EasyCaching.Redis` for the Redis cache provider.
           );
        }
    }
}
