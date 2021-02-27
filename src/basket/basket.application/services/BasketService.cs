using AutoMapper;
using basket.application.interfaces;
using basket.application.models;
using basket.domain.interfaces;
using infra.eventbus.events;
using infra.eventbus.interfaces;
using System;
using System.Threading.Tasks;

namespace basket.application.services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        public BasketService(IBasketRepository basketRepository, IMapper mapper, IEventBus eventBus)
        {
            this._basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<bool> Checkout(BasketCartCheckout basketCartCheckout)
        {
            // get total price of the basket
            // remove the basket 
            // send checkout event to rabbitMq 

            BasketCart basket = _mapper.Map<BasketCart>(await _basketRepository.Get(basketCartCheckout.UserName));
            if (basket == null)
            {
                throw new Exception(String.Format("Basket not exist with this user : {EventId}", basketCartCheckout.UserName));
            }

            var basketRemoved = await _basketRepository.Delete(basketCartCheckout.UserName);
            if (!basketRemoved)
            {
                throw new Exception(String.Format("Basket can not deleted : {EventId}", basketCartCheckout.UserName));
            }

            // Once basket is checkout, sends an integration event to
            // ordering.api to convert basket to order and proceeds with
            // order creation process

            BasketCartCheckoutEvent basketCartCheckoutEvent = _mapper.Map<BasketCartCheckoutEvent>(basketCartCheckout);
            basketCartCheckoutEvent.TotalPrice = basket.TotalPrice;

            _eventBus.Publish(basketCartCheckoutEvent);
            return await Task.FromResult(true);

        }

        public async Task<bool> Delete(string userName)
        {
            return await _basketRepository.Delete(userName);
        }

        public async Task<BasketCart> Get(string userName)
        {
            return _mapper.Map<BasketCart>(await _basketRepository.Get(userName));
        }

        public async Task<BasketCart> Update(BasketCart basket)
        {
            var basketForUpdate = _mapper.Map<basket.domain.models.BasketCart>(basket);
            return _mapper.Map<BasketCart>(await _basketRepository.Update(basketForUpdate));

        }

    }
}
