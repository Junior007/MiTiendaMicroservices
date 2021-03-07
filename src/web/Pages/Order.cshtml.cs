using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.ApiCollection.Interfaces;
using web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web
{
    public class OrderModel : PageModel
    {
        private readonly IOrderApi _orderApi;

        public OrderModel(IOrderApi orderApi)
        {
            _orderApi = orderApi ?? throw new ArgumentNullException(nameof(orderApi));
        }

        public IEnumerable<OrderResponseModel> Orders { get; set; } = new List<OrderResponseModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _orderApi.GetOrdersByUserName("swn");

            return Page();
        }       
    }
}