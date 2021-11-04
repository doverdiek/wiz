using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models.Requests
{
    public class ProductImageRequest
    {

        public IFormFile image { get; set; }  
        
        public string productId { get; set; }

    }
}
