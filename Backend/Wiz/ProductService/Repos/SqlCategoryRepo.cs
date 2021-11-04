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
    public class SqlCategoryRepo : SqlCrudRepo<Category>, ICategoryRepo
    {
        public SqlCategoryRepo(WizDBContext context) : base(context) { }
        public void AddProduct(string categoryid, string productid)
        {
            var category = GetSpecificRecord(categoryid);
            if (category.ProductIds == null)
                category.ProductIds = new List<string>();
            category.ProductIds.Add(productid);
            UpsertRecord(category);
        }

        public void AddSubCategory(string parentid, string categoryid)
        {
            var parentCategory = GetSpecificRecord(parentid);
            var subCategory = GetSpecificRecord(categoryid);
            subCategory.ParentCategoryId = parentid;
            if (parentCategory.SubCategoriesIds == null)
                parentCategory.SubCategoriesIds = new List<string>();
            parentCategory.SubCategoriesIds.Add(categoryid);
            UpsertRecord(parentCategory);
            UpsertRecord(subCategory);
        }

        public void RemoveProduct(string categoryid, string productid)
        {
            var category = GetSpecificRecord(categoryid);
            category.ProductIds = category.ProductIds.Where(p => p != productid).ToList();
            UpsertRecord(category);
        }

        public void RemoveSubCategory(string parentid, string categoryid)
        {
            var parentCategory = GetSpecificRecord(parentid);
            var subCategory = GetSpecificRecord(categoryid);
            subCategory.ParentCategoryId = null;
            parentCategory.SubCategoriesIds = parentCategory.SubCategoriesIds.Where(sb => sb != categoryid).ToList();
            UpsertRecord(parentCategory);
            UpsertRecord(subCategory);
        }

        public List<CategoryProperty> GetCategoryProperties(Category category)
        {
            var propertylist = new List<CategoryProperty>();
            var currentcategory = category;
            propertylist.AddRange(currentcategory.Properties);
            while (currentcategory.ParentCategoryId != null)
            {
                currentcategory = GetSpecificRecord(currentcategory.ParentCategoryId);
                if (currentcategory.Properties != null)
                {
                    propertylist.AddRange(currentcategory.Properties);
                }
            }
            return propertylist;
        }
    }
}
