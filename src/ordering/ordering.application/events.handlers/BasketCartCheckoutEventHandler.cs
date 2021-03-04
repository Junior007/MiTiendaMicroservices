using AutoMapper;
using infra.eventbus.events;
using infra.eventbus.interfaces;
using ordering.domain.interfaces;
using ordering.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordering.application.events.handlers
{
    public class BasketCartCheckoutEventHandler : IEventHandler<BasketCartCheckoutEvent>
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IMapper _mapper;

        public BasketCartCheckoutEventHandler(IOrdersRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper=mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(BasketCartCheckoutEvent @event)
        {
            ordering.domain.models.Order order = _mapper.Map<Order>(@event);
            if (order == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newOrder = _mapper.Map<ordering.application.models.Order>(_orderRepository.Add(order));

            await _orderRepository.SaveChanges();

            return true;
        }

    }
}

