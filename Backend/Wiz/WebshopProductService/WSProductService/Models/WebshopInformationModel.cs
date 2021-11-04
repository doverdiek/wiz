using AbstractModels;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSInformationService.Models
{
    public class WebshopInformationModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string Title { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj is WebshopInformationModel)
            {
                var that = obj as WebshopInformationModel;
                if (this.Products.Equals(that.Products) && this.Categories.Equals(that.Categories) && this.Title.Equals(that.Title)) 
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Categories, Products, Title);
        }
    }
}
