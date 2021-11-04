using AbstractModels;
using DataModels;
using System.Collections.Generic;

namespace ProductService.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAllCategories(string userId);
        public Category GetCategoryDetails(string categoryId);
        public void DeleteCategory(string categoryId);
        public Category UpsertCategory(Category category);
        public void AddProduct(string categoryId, string productId);
        public void AddSubCategory(string parentCategory, string childCategory);
    }
}