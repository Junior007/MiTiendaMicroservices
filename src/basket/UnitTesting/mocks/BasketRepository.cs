using basket.domain.interfaces;
using basket.domain.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.mocks
{
    public class BasketRepository : IBasketRepository
    {

        private static Dictionary<string, BasketCart> _basketCarts;
        public  BasketRepository()
        {
            if (_basketCarts == null)
                _basketCarts = new Dictionary<string, BasketCart>();

        }
        public async Task<BasketCart> Get(string userName)
        {
            BasketCart basket;
            _basketCarts.TryGetValue(userName, out basket);

            return basket;
        }

        public async Task<BasketCart> Update(BasketCart basket)
        {
            _basketCarts.Remove(basket.UserName);
            _basketCarts.Add(basket.UserName, basket);

            return await Get(basket.UserName);
        }

        public async Task<bool> Delete(string userName)
        {
            _basketCarts.Remove(userName);
            return true;
        }
    }
}
