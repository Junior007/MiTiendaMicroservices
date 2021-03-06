﻿using web.ApiCollection.Infrastructure;
using web.ApiCollection.Interfaces;
using web.Models;
using web.Settings;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace web.ApiCollection
{
    public class BasketApi : BaseHttpClientWithFactory, IBasketApi
    {
        private readonly IApiSettings _settings;

        public BasketApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            _settings = settings;
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                               .SetPath(_settings.BasketPath+ string.Format("/{0}", userName) )
                               //.AddQueryString("username", userName)
                               .HttpMethod(HttpMethod.Get)
                               .GetHttpMessage();

            return await SendRequest<BasketModel>(message);
        }

        public async Task<BasketModel> UpdateBasket(BasketModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.BasketPath + string.Format("/{0}", model.UserName))
                                .HttpMethod(HttpMethod.Put)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<BasketModel>(message);
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.BasketPath)
                                .AddToPath("Checkout")
                                .HttpMethod(HttpMethod.Post)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(model);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            await SendRequest<BasketCheckoutModel>(message);
        }

        public async  Task<BasketModel> AddItem(BasketItemModel basketItemModel, string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.BasketPath)
                                .AddToPath(string.Format("AddItem/{0}", userName))
                                .HttpMethod(HttpMethod.Put)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(basketItemModel);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<BasketModel>(message);
        }

        public async Task<BasketModel> RemoveItem(BasketItemModel basketItemModel, string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                                .SetPath(_settings.BasketPath)
                                .AddToPath(string.Format("RemoveItem/{0}", userName))
                                .HttpMethod(HttpMethod.Put)
                                .GetHttpMessage();

            var json = JsonConvert.SerializeObject(basketItemModel);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest<BasketModel>(message);
        }
    }
}
