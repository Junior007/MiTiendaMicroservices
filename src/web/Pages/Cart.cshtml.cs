﻿using System;
using System.Linq;
using System.Threading.Tasks;
using web.ApiCollection.Interfaces;
using web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web
{
    public class CartModel : PageModel
    {
        private readonly IBasketApi _basketApi;

        public CartModel(IBasketApi basketApi)
        {
            _basketApi = basketApi ?? throw new ArgumentNullException(nameof(basketApi));
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "swn";
            Cart = await _basketApi.GetBasket(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var userName = "swn";
            var basket = await _basketApi.GetBasket(userName);

            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            //basket.Items.Remove(item);

            //var basketUpdated = await _basketApi.UpdateBasket(basket);

            var basketUpdated = await _basketApi.RemoveItem(item, userName);

            return RedirectToPage();
        }
    }
}