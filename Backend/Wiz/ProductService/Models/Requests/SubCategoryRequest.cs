using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models.Requests
{
    public class SubCategoryRequest
    {
        public string ParendCategoryId { get; set; }
        public string ChildCategoryId { get; set; }
    }
}

