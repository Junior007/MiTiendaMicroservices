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
            _dbContext = dbContext;
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
            //await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Update(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync();
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
            //await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
