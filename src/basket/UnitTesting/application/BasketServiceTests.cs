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
        public void AddSameItem()
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


            var basket = (_basketService.Get(userName1)).Result;

            var itemResult = basket.Items.FirstOrDefault();

            Assert.AreEqual(basket.Items.Count, 1);
            Assert.AreEqual(basket.TotalPrice, itemResult.Quantity * itemResult.Price);

            Assert.AreEqual(itemResult.Color, color);
            Assert.AreEqual(itemResult.Price, price);
            Assert.AreEqual(itemResult.ProductId, productId);
            Assert.AreEqual(itemResult.ProductName, productName);
            Assert.AreEqual(itemResult.Quantity, quantity *iter);

        }

        [TestMethod]
        public void AddDistinctsItems()
        {

            string userName = "agg1";


            string color1 = "red";
            decimal price1 = 123.54M;
            string productId1 = "1111";
            string productName1 = "item1";
            int quantity1 = 7;



            string color2 = "green";
            decimal price2 = 23.54M;
            string productId2 = "2222";
            string productName2 = "item2";
            int quantity2 = 5;

            int iter = 3;

            BasketCartItem item1 = new BasketCartItem
            {
                Color = color1,
                Price = price1,
                ProductId = productId1,
                ProductName = productName1,
                Quantity = quantity1


            };


            BasketCartItem item2 = new BasketCartItem
            {
                Color = color2,
                Price = price2,
                ProductId = productId2,
                ProductName = productName2,
                Quantity = quantity2


            };


            BasketCart basket = null;
            for (var i = 0; i < iter; i++)
                basket = _basketService.AddItem(userName, item1).Result;
            for (var i = 0; i < iter; i++)
                basket =  _basketService.AddItem(userName, item2).Result;


            var items = basket.Items;

            Assert.AreEqual(basket.Items.Count, 2);

            var itemsResult1 = items.Where(item => item.ProductId == item1.ProductId);
            var itemResult1 = itemsResult1.FirstOrDefault();

            Assert.AreEqual(itemsResult1.Count(), 1);


            Assert.AreEqual(itemResult1.Color, color1);
            Assert.AreEqual(itemResult1.Price, price1);
            Assert.AreEqual(itemResult1.ProductId, productId1);
            Assert.AreEqual(itemResult1.ProductName, productName1);
            Assert.AreEqual(itemResult1.Quantity, quantity1 * iter);



            var itemsResult2 = items.Where(item => item.ProductId == item2.ProductId);

            Assert.AreEqual(itemsResult2.Count(), 1);

            var itemResult2 = itemsResult2.FirstOrDefault();

            Assert.AreEqual(itemResult2.Color, color2);
            Assert.AreEqual(itemResult2.Price, price2);
            Assert.AreEqual(itemResult2.ProductId, productId2);
            Assert.AreEqual(itemResult2.ProductName, productName2);
            Assert.AreEqual(itemResult2.Quantity, quantity2 * iter);



            Assert.AreEqual(basket.TotalPrice, itemResult1.Quantity * itemResult1.Price + itemResult2.Quantity * itemResult2.Price);




        }

        /*[TestMethod]
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

        }*/


    }
}
