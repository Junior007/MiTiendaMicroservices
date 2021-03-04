using System;

namespace ordering.domain.models
{
    public class Order
    {
        private string id { get; set; }
        public Order()
        {
            Date = DateTime.Now;
        }

        public string Id
        {
            get
            {   if (id == null)
                    id = string.Format("{0}-{1}",Date.ToString("yyyyMMdd hh:mm:ss"), UserName);
                return id;
            }
            set
            {
                id = value;
            }

        }
        public DateTime Date { get; set; }
        //
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
