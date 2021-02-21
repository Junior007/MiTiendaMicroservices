using basket.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basket.domain.interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart> Get(string userName);
        Task<BasketCart> Update(BasketCart basket);
        Task<bool> Delete(string userName);
    }
}
