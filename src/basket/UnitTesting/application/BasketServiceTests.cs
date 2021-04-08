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
using System.Linq;

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

        /*[TestMethod]
        public void Get()
        {
            var bk = _basketService.Get("agg");
        }*/
        [TestMethod]
        public async void AddSameItem()
        {
            string color = "red";
            decimal price = 123.54M;
            string productId = "1111";
            string productName = "item1";
            int quantity = 7;
            string userName1 = "agg1";
            int iter = 3;

            BasketCartItem item1 = new BasketCartItem
            {
                Color = color,
                Price = price,
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity


            };



            for (var i = 0; i < iter; i++)
                _basketService.AddItem(userName1, item1);


            var basket = (await _basketService.Get(userName1));

            var item = basket.Items.FirstOrDefault();
            /*
            Assert.AreEqual(basket.Items.Count, 1);
            Assert.AreEqual(basket.TotalPrice, item.Quantity * item.Price);

            Assert.AreEqual(item.Color, color);
            Assert.AreEqual(item.Price, price);
            Assert.AreEqual(item.ProductId, productId);
            Assert.AreEqual(item.ProductName, productName);
            Assert.AreEqual(item.Quantity, quantity *iter);
            */

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
