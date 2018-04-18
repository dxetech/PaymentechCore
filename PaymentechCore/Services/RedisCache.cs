using System;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace PaymentechCore.Services
{
    public class RedisCacheOptions
    {
        public string Host { get; set; }
    }

    public class RedisCache : IPaymentechCache
    {
        private readonly RedisCacheOptions _options;
        private readonly ConnectionMultiplexer _redis;

        public RedisCache(IOptions<RedisCacheOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
            _redis = ConnectionMultiplexer.Connect(_options.Host);
        }

        public string GetValue(string key)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(key);
        }

        public void SetValue(string key, string value)
        {
            var db = _redis.GetDatabase();
            db.StringSet(key, value);
        }
    }
}