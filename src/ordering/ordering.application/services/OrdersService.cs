using AutoMapper;
using ordering.application.interfaces;
using ordering.application.models;
using ordering.domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordering.application.services
{
   
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository?? throw new ArgumentNullException(nameof(orderRepository)); ;
            _mapper= mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Order>> GetOrdersByUser(string userName)
        {
            return _mapper.Map<IEnumerable<Order>>(await _orderRepository.GetByUserName(userName));
        }

        public async Task<bool> CreateOrder(Order order)
        {
            var orderForCreate = _mapper.Map<ordering.domain.models.Order>(order);

            _orderRepository.Add(orderForCreate);

            await _orderRepository.SaveChanges();

            return true;
        }
    }
}
