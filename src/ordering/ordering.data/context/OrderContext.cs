using ordering.domain.models;
using Microsoft.EntityFrameworkCore;
namespace ordering.data.context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
           
        }

        public virtual   DbSet<Order> Orders { get; set; }
    }
}
