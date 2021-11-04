using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class Order
    {
        public DateTime Date { get; set; }
        public List<Product> Products { get; set; }
        public WebshopClient Client { get; set; }
    }
}
