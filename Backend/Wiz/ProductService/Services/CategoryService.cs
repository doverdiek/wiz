using AbstractModels;
using DataModels;
using MongoDB.Driver;
using ProductService.Models;
using ProductService.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IProductRepo productRepo;
        public CategoryService(ICategoryRepo categoryRepo, IProductRepo productRepo)
        {
            this.categoryRepo = categoryRepo;
            this.productRepo = productRepo;
        }

        public void AddProduct(string categoryId, string productId)
        {
            categoryRepo.AddProduct(categoryId, productId);
            var product = productRepo.GetSpecificRecord(productId);
            product.Category = categoryId;
            productRepo.UpsertRecord(product);
        }

        public void AddSubCategory(string parentCategory, string childCategory)
        {
            categoryRepo.AddSubCategory(parentCategory, childCategory);
        }

        public void DeleteCategory(string categoryId)
        {
            categoryRepo.DeleteRecord(categoryId);
        }

        public IEnumerable<Category> GetAllCategories(string UserId)
        {
            return categoryRepo.GetAllDocuments(UserId);
        }


        public Category GetCategoryDetails(string categoryId)
        {
            var category = categoryRepo.QueryAble.First(a => a.Id == categoryId);
            if (category.ProductIds != null)
                category.Products = productRepo.QueryAble.Where(a => category.ProductIds.Contains(a.Id)).ToList();

            var categoryCollection = categoryRepo.QueryAble;
            if (category.SubCategoriesIds != null)
                category.SubCategories = categoryCollection.Where(a => category.SubCategoriesIds.Contains(a.Id)).ToList();
            category.Properties = GetCategoryProperties(category);
            return category;
        }

        private List<CategoryProperty> GetCategoryProperties(Category category)
        {
            return categoryRepo.GetCategoryProperties(category);
        }

        public Category UpsertCategory(Category category)
        {
            return categoryRepo.UpsertRecord(category);
        }
    }
}
