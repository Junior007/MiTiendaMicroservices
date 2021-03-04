using ordering.domain.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ordering.domain.interfaces
{
    public interface IOrdersRepository
    {
        Task<IReadOnlyList<Order>> Get();
        Task<IEnumerable<Order>> GetByUserName(string userName);
        Order Add(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        Task SaveChanges();
    }
}
