using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractDataModels.Repo;
using AbstractModels;
using DataModels;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using ProductService.Models;

namespace ProductService.Repos
{
    public class MongoProductRepo : MongoDBCollection<Product>, IProductRepo
    {
        public MongoProductRepo(IMongoDatabase database, string collectionName) : base(database, collectionName){}

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
