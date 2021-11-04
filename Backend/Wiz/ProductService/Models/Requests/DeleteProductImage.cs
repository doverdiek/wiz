using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models.Requests
{
    public class DeleteProductImage
    {
        public string ImagePath { get; set; }
        public string ProductId { get; set; }
    }
}
