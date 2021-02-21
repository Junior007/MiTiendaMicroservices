using System.Collections.Generic;

namespace basket.application.models
{


    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        public BasketCart()
        {
        }

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice { get; set; }
    }

}
