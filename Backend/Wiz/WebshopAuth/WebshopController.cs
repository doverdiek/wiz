using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebshopAuth
{
    public class WebshopController : ControllerBase
    {
        public string CustomerId { get => RetrieveCustomerHeader(); }

        private string RetrieveCustomerHeader()
        {
            if (Request.Headers.TryGetValue("customer", out var customervalue) && !string.IsNullOrEmpty(customervalue))
            {
                return customervalue;
            }
            throw new NullReferenceException("customer header not set");
        }
    }
}
