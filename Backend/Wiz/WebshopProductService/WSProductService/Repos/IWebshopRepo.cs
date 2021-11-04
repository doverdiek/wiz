using AbstractModels;
using DataModels;
using System.Collections.Generic;

namespace WSInformationService.Repos
{
    public interface IWebshopRepo
    {
        IEnumerable<Category> GetCategories(string customerid);
        IEnumerable<Product> GetProducts(string customerid);
        string GetTitle(string customerid);
    }
}