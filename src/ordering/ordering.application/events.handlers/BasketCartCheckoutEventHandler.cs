using AutoMapper;
using infra.eventbus.events;
using infra.eventbus.interfaces;
using ordering.application.interfaces;
using ordering.application.models;
using System;
using System.Threading.Tasks;

namespace ordering.application.events.handlers
{
    public class BasketCartCheckoutEventHandler : IEventHandler<BasketCartCheckoutEvent>
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        public BasketCartCheckoutEventHandler(IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService ?? throw new ArgumentNullException(nameof(ordersService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(BasketCartCheckoutEvent @event)
        {
            Order order = _mapper.Map<Order>(@event);
            if (order == null)
                throw new ApplicationException($"Entity could not be mapped.");

            return await _ordersService.CreateOrder(order);
        }

    }
}

