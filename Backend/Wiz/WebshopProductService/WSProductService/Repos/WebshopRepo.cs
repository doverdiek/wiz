
using AbstractModels;
using DataModels;
using MongoDB.Driver;
using MongoDBCrudLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSInformationService.Repos
{
    public class WebshopRepo : IWebshopRepo
    {
        private readonly IMongoDBCollection<Category> categoryRepo;
        private readonly IMongoDBCollection<Product> productRepo;
        private readonly IMongoDBCollection<User> userRepo;

        public WebshopRepo(
            IMongoDBCollection<Category> categoryRepo,
           IMongoDBCollection<Product> productRepo,
            IMongoDBCollection<User> userRepo)
        {
            this.categoryRepo = categoryRepo;
            this.productRepo = productRepo;
            this.userRepo = userRepo;
        }

        public IEnumerable<Category> GetCategories(string customerid)
        {
            return categoryRepo.GetAllDocuments(customerid);
        }

        public IEnumerable<Product> GetProducts(string customerid)
        {
            return productRepo.GetAllDocuments(customerid);
        }

        public string GetTitle(string customerid)
        {
            return userRepo.Collection.AsQueryable().FirstOrDefault(a => a.CustomerId == customerid)?.Title ?? "";
        }



    }
}
