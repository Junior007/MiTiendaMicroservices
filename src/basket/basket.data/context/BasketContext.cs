using basket.data.interfaces;
using StackExchange.Redis;

namespace basket.data.context
{
    public class BasketContext : IBasketContext
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public BasketContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            Redis = redisConnection.GetDatabase();
        }        

        public IDatabase Redis { get; }
    }
}
