using AutoMapper;
using basket.application.models;
using basket.application.services;
using basket.data.context;
using basket.data.interfaces;
using basket.data.repositories;
using basket.domain.interfaces;
using basket.IoC;
using infra.eventbus.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace UnitTesting.application
{
    [TestClass]
    public class BasketServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private readonly BasketService _basketService;
        private readonly IBasketRepository _basketRepository;

        public BasketServiceTests()
        {
            //#Event Bus
            _eventBus = new Mock<IEventBus>().Object;
            //# AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            _mapper = mappingConfig.CreateMapper();
            _basketRepository = new mocks.BasketRepository();
            _basketService = new BasketService(_basketRepository, _mapper, _eventBus);

        }

        [TestMethod]
        public void Get()
        {
            var bk = _basketService.Get("agg");
        }
        [TestMethod]
        public void AddSameItem()
        {
            BasketCartItem item1 = new BasketCartItem
            {
                Color = "red",
                Price = 123.54M,
                ProductId = "1111",
                ProductName = "item1",
                Quantity = 7


            };

            var userName1 = "agg1";
            var userName2 = "agg2";

            _basketService.AddItem(userName1, item1);
            _basketService.AddItem(userName1, item1);
            _basketService.AddItem(userName1, item1);

            
            _basketService.AddItem(userName2, item1);
            _basketService.AddItem(userName2, item1);
            _basketService.AddItem(userName2, item1);
            
        }
        [TestMethod]
        public void RemoveItem()
        {

        }
        [TestMethod]
        public void Checkout()
        {

        }
        [TestMethod]
        public void Delete()
        {

        }


    }
}
