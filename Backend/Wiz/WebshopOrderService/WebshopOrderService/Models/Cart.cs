using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopOrderService.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }
    }
}
