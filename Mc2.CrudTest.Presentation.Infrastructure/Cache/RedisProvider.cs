using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Mc2.CrudTest.Presentation.Infrastructure.Cache
{
    /// <summary>
    /// Distributed Cache Provider
    /// </summary>
    public static class RedisProvider
    {
        /// <summary>
        /// Distributed Cache Provider
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="providerName"></param>
        public static void AddRedisCacheProvider(this IServiceCollection services,
            IConfiguration configuration, string providerName)
        {
            //configuration
            services.AddEasyCaching(options =>
            {

                // add some serialization settings
                Action<EasyCaching.Serialization.Json.EasyCachingJsonSerializerOptions> easyCaching = x =>
                {
                    x.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                };

                options.WithJson(easyCaching, providerName);

                //use redis cache that named redis1
                options.UseRedis(configuration, providerName);
            });

        }
    }
}
