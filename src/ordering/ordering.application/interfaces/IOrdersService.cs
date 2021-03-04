using ordering.application.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordering.application.interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetOrdersByUser(string userName);
        Task<bool> CreateOrder(Order order);
    }
}
