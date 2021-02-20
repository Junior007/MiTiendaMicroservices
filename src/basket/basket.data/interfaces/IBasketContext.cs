using StackExchange.Redis;

namespace basket.data.interfaces
{
    public interface IBasketContext
    {
        IDatabase Redis { get; }
    }
}
