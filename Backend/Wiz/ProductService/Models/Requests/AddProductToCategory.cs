using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models.Requests
{
    public class AddProductToCategory
    {
        public string ProductId {get; set;}
        
        public string CategoryId { get; set; }

    }
}
