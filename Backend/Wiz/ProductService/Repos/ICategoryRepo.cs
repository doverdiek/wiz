using AbstractDataModels.Repo;
using AbstractModels;
using DataModels;
using MongoDBCrudLibrary;

using ProductService.Models;
using System.Collections.Generic;

namespace ProductService.Repos
{
    public interface ICategoryRepo : ICrudRepo<Category>
    {
        void AddProduct(string categoryid, string productid);
        void AddSubCategory(string parentid, string categoryid);
        void RemoveProduct(string categoryid, string productid);
        void RemoveSubCategory(string parentid, string categoryid);
        List<CategoryProperty> GetCategoryProperties(Category category);
    }
}