using StackExchange.Redis;

namespace basket.data.interfaces
{
    public interface IBasketContext
    {

        bool Check();
        IDatabase Redis { get; }

       
    }
}
