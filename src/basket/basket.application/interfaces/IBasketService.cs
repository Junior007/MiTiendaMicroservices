using basket.application.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basket.application.interfaces
{
    public interface IBasketService
    {
        Task<BasketCart> Get(string userName);
        Task<BasketCart> Update(BasketCart basket);
        Task<bool> Delete(string userName);
        Task Checkout(BasketCheckout basketCheckout);
    }
}
