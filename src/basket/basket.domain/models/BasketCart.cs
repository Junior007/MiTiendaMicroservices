using System.Collections.Generic;
using System.Linq;

namespace basket.domain.models
{
    public class BasketCart
    {        
        public string UserName { get; protected set; }
        public List<BasketCartItem> Items { get; protected set; } = new List<BasketCartItem>();

        /*public BasketCart(string userName)
        {
            UserName = userName;
        }*/

        public BasketCart(string userName)
        {
            UserName = userName;
        }
        public void AddItem(BasketCartItem item)
        {
            var itemFromBasket = Items.Where(it => it.ProductId == item.ProductId).FirstOrDefault();
            if (itemFromBasket!=null)
                Items.Where(it => it.ProductId == item.ProductId).FirstOrDefault().Quantity += item.Quantity;
            else
                Items.Add(item);
        }
        public void RemoveItem(BasketCartItem item)
        {
            var itemFromBasket = Items.Where(it => it.ProductId == item.ProductId).FirstOrDefault();
            if (itemFromBasket != null)
                Items.Remove(itemFromBasket);

        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }

                return totalprice;
            }
        }
    }
}
