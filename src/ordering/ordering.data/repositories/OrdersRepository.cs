using Microsoft.EntityFrameworkCore;
using ordering.domain.models;
using ordering.domain.interfaces;
using System.Collections.Generic;
using ordering.data.context;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace ordering.data.repositories
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly OrderContext _dbContext;
        public OrdersRepository(OrderContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
        }

        public async Task<IReadOnlyList<Order>> Get()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByUserName(string userName)
        {
            return await _dbContext.Orders.Where(ord => ord.UserName == userName).ToListAsync();
        }

        public Order Add(Order entity)
        {
            _dbContext.Orders.Add(entity);
            return entity;
        }

        public void Update(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
