using AutoMapper;
using basket.application.interfaces;
using basket.application.models;
using basket.domain.interfaces;
using System;
using System.Threading.Tasks;

namespace basket.application.services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IBasketRepository basketRepository, IMapper mapper)
        {
            this._basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task Checkout(BasketCheckout basketCheckout)
        {
            throw new NotImplementedException();

            // get total price of the basket
            // remove the basket 
            // send checkout event to rabbitMq 
            /*
            var basket = await _repository.GetBasket(basketCheckout.UserName);
            if (basket == null)
            {
                _logger.LogError("Basket not exist with this user : {EventId}", basketCheckout.UserName);
                return BadRequest();
            }

            var basketRemoved = await _repository.DeleteBasket(basketCheckout.UserName);
            if (!basketRemoved)
            {
                _logger.LogError("Basket can not deleted");
                return BadRequest();
            }

            // Once basket is checkout, sends an integration event to
            // ordering.api to convert basket to order and proceeds with
            // order creation process

            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.RequestId = Guid.NewGuid();
            eventMessage.TotalPrice = basket.TotalPrice;

            try
            {
                _eventBus.PublishBasketCheckout(EventBusConstants.BasketCheckoutQueue, eventMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {EventId} from {AppName}", eventMessage.RequestId, "Basket");
                throw;
            }
            */

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
