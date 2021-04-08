using basket.data.interfaces;
using basket.domain.interfaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using basket.domain.models;

namespace basket.data.repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;
        private readonly string _className;

        private string Key(string userName)
        {
            return $"{_className}-{userName}";

        }

        public BasketRepository(IBasketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _className = nameof(BasketRepository);
        }

        public async Task<BasketCart> Get(string userName)
        {
            var basket = await _context
                                .CacheDB
                                .StringGetAsync(Key(userName));
            if (basket.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> Update(BasketCart basket)
        {
            var updated = await _context
                              .CacheDB
                              .StringSetAsync(Key(basket.UserName), JsonConvert.SerializeObject(basket));
            if (!updated)
            {                
                return null;
            }            
            return await Get(basket.UserName);            
        }

        public async Task<bool> Delete(string userName)
        {
            return await _context
                            .CacheDB
                            .KeyDeleteAsync(Key(userName));
        }
    }
}
