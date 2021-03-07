using web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web.ApiCollection.Interfaces
{
    public interface IOrderApi
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
