using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models.Requests;

using ProductService.Services;

using System.Collections.Generic;
using System.Linq;

using BackOfficeAuth;
using DataModels;

namespace ProductService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CategoryController : BackOfficeController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("All")]
        public List<Category> GetProductCategories()
        {

            return _categoryService.GetAllCategories(UserId).ToList();
        }

        [HttpPost("Upsert")]
        public Category UpsertCategory(Category productCategory)
        {
            productCategory.CustomerId = UserId;
            return _categoryService.UpsertCategory(productCategory);
        }

        [HttpPost("AddProduct")]
        public void AddProduct([FromBody]AddProductToCategory productToCategory)
        {
            _categoryService.AddProduct(productToCategory.CategoryId, productToCategory.ProductId);
        }

        [HttpPost("AddSubCategory")]
        public void AddSubCategory(SubCategoryRequest subCategoryRequest)
        {
            _categoryService.AddSubCategory(subCategoryRequest.ParendCategoryId, subCategoryRequest.ChildCategoryId);
        }

        [HttpDelete("Delete/{id}")]
        public void DeleteCategory(string id)
        {
            _categoryService.DeleteCategory(id);
        }

        [HttpGet("{id}")]
        public Category GetCategoryDetails(string id)
        {
            return _categoryService.GetCategoryDetails(id);
        }
    }
}
