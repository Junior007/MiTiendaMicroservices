using ordering.domain.models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ordering.data.context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
           
        }

        public virtual   DbSet<Order> Orders { get; set; }

        public bool IsOpen()
        {
            return this.Database.GetDbConnection().State == System.Data.ConnectionState.Open;
        }
    }
}
