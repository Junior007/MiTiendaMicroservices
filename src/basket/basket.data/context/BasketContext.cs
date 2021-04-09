using basket.data.interfaces;
using StackExchange.Redis;

namespace basket.data.context
{
    public class BasketContext : IBasketContext
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public BasketContext(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            CacheDB = redisConnection.GetDatabase();
        }        

        public IDatabase CacheDB { get; }

        public bool IsOpen()
        {

            return _redisConnection.IsConnected;

        }
    }
}
