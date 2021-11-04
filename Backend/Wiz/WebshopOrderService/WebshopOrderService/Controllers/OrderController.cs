using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAuth;
using WebshopOrderService.Models;

namespace WebshopOrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : WebshopController
    {
        public OrderController()
        {

        }
        public void CreateOrder(Cart cart)
        {

        }
    }
}
