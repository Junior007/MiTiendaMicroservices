using ordering.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ordering.domain.interfaces
{
    public interface IOrderRepository//<Order> //where Order : Entity
    {
        Task<IReadOnlyList<Order>> Get();
        Task<IEnumerable<Order>> GetByUserName(string userName);
        Task<Order> Add(Order entity);
        Task Update(Order entity);
        Task Delete(Order entity);
    }
}
