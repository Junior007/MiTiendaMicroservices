using StackExchange.Redis;

namespace basket.data.interfaces
{
    public interface IBasketContext
    {

        bool IsOpen();
        IDatabase CacheDB { get; }

       
    }
}
