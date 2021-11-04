using AbstractModels;
using AutoMapper;
using DataModels;
using SqlDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repos
{
    public class SqlProductRepo : SqlCrudRepo<Product>, IProductRepo
    {
        public SqlProductRepo(WizDBContext context) : base(context) { }

        public new IQueryable<Product> QueryAble => base.QueryAble;

        public void AddCategory(string categoryid, string productid)
        {
            var product = GetSpecificRecord(productid);
            if (product.Category == null)
                product.Category = categoryid;
            UpsertRecord(product);
        }

        public void AddProductImage(string path, string productId, string userId)
        {
            var product = GetSpecificRecord(productId);
            if (product.Images != null)
            {
                var imageslist = product.Images.ToList();
                imageslist.Add(path);
                product.Images = imageslist.ToArray();
            }
            else
            {
                product.Images = new string[] { path };
            }
            UpsertRecord(product);
        }

        public void DeleteProductImage(Product product, string imagepath)
        {
            var image = product.Images.FirstOrDefault(a => a == imagepath);
            if (image != null)
            {
                product.Images = product.Images.Where(a => a != image).ToArray();
                UpsertRecord((Product)product);
            }
        }

        public void SetProductPropertyValue(List<CategoryProperty> categoryProperties, string productId)
        {
            var product = GetSpecificRecord(productId);
            product.Properties = categoryProperties;
            UpsertRecord(product);
        }
    }
}
