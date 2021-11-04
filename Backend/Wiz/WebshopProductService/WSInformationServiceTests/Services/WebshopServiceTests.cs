using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSInformationService.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WSInformationService.Repos;
using Moq;
using MongoDBCrudLibrary;
using DataModels;
using WSInformationService.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using MongoDB.Driver.Core.Servers;

namespace WSInformationService.Services.Tests
{
    [TestClass()]
    public class WebshopServiceTests
    {

        [TestMethod()]
        public void GetWebshopInformationTestSucceeded()
        {
            //Arrange
            var webshopmock = new Mock<IWebshopRepo>();
            List<Category> categories = new List<Category>
            {
                new Category
                { 
                    CategoryName = "category1",
                    Id = "1"
                },
                new Category
                { 
                    CategoryName = "category2",
                    Id = "2"
                }
            };
            List<Product> products = new List<Product>
            {
                new Product
                { 
                    Name = "product1",
                    Id = "1"
                },
                new Product
                { 
                    Name = "product2",
                     Id = "2"
                }
            };
            var wsinformation = new WebshopInformationModel
            {
                Categories = categories,
                Products = products,
                Title = "TestTitle"
            };
            webshopmock.Setup(a => a.GetCategories("test")).Returns(categories);
            webshopmock.Setup(a => a.GetProducts("test")).Returns(products);
            webshopmock.Setup(a => a.GetTitle("test")).Returns("TestTitle");
            WebshopService webshopService = new WebshopService(webshopmock.Object);
            //Act
            var returnedcall = webshopService.GetWebshopInformation("test");

            //Assert
            Assert.AreEqual(wsinformation, returnedcall);
        }

        [TestMethod()]
        public void GetWebshopInformationTestErrorThrown()
        {
            //Arrange
            var webshopmock = new Mock<IWebshopRepo>();
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    CategoryName = "category1",
                    Id = "1"
                },
                new Category
                {
                    CategoryName = "category2",
                    Id = "2"
                }
            };
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Name = "product1",
                    Id = "1"
                },
                new Product
                {
                    Name = "product2",
                     Id = "2"
                }
            };
            var wsinformation = new WebshopInformationModel
            {
                Categories = categories,
                Products = products,
                Title = "TestTitle"
            };
            webshopmock.Setup(a => a.GetCategories("test")).Throws(new Exception());
            webshopmock.Setup(a => a.GetProducts("test")).Returns(products);
            webshopmock.Setup(a => a.GetTitle("test")).Returns("TestTitle");
            WebshopService webshopService = new WebshopService(webshopmock.Object);
            //Assert
            Assert.ThrowsException<Exception>(() => webshopService.GetWebshopInformation("test"));

        }

    }
}
