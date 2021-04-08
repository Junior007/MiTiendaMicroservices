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
            Redis = redisConnection.GetDatabase();
        }        

        public IDatabase Redis { get; }

        public bool IsOpen()
        {

            return _redisConnection.IsConnected;

        }
    }
}
