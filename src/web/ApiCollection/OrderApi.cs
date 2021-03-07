using web.ApiCollection.Infrastructure;
using web.ApiCollection.Interfaces;
using web.Models;
using web.Settings;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace web.ApiCollection
{
    public class OrderApi : BaseHttpClientWithFactory, IOrderApi
    {
        private readonly IApiSettings _settings;

        public OrderApi(IHttpClientFactory factory, IApiSettings settings)
            : base(factory)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var message = new HttpRequestBuilder(_settings.BaseAddress)
                           .SetPath(_settings.OrderPath)
                           .AddQueryString("username", userName)
                           .HttpMethod(HttpMethod.Get)
                           .GetHttpMessage();

            return await SendRequest<IEnumerable<OrderResponseModel>>(message);
        }
    }
}
