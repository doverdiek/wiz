using AbstractDataModels.Repo;
using AbstractModels;
using DataModels;
using MongoDBCrudLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Repos
{
    public interface IProductRepo
    {
        public IQueryable<Product> QueryAble { get; }
        void SetProductPropertyValue(List<CategoryProperty> categoryProperties, string productId);
        void AddCategory(string categoryId, string productId);
        void AddProductImage(string fileName, string productId, string userId);
        void DeleteProductImage(Product product, string imagepath);
        public void DeleteRecord(Product document);
        public void DeleteRecord(string documentId);
        public IEnumerable<Product> GetAllDocuments(string UserId);
        public Product GetSpecificRecord(string documentId);
        public Product UpsertRecord(Product document);
    }
}
