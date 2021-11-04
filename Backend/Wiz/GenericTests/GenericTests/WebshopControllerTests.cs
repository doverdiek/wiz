using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using WebshopAuth;
using Xunit;

namespace GenericTests
{
    public class WebshopControllerTests
    {
        [Fact]
        public void HeaderNotFound()
        {
            //Arrange
            var httpcontext = new DefaultHttpContext();
            var webshopController = new WebshopController();
           
            //act
            httpcontext.Request.Headers["geen customer header"] = "";
            webshopController.ControllerContext = new ControllerContext { HttpContext = httpcontext };

            //Assert
            var exception = Assert.Throws<NullReferenceException>(() => webshopController.CustomerId);
            Assert.Equal("customer header not set", exception.Message);
        }

        [Fact]
        public void HeaderIsEmpty()
        {
            //Arrange
            var httpcontext = new DefaultHttpContext();
            var webshopController = new WebshopController();

            //act
            httpcontext.Request.Headers["customer"] = "";
            webshopController.ControllerContext = new ControllerContext { HttpContext = httpcontext };

            //Assert
            var exception = Assert.Throws<NullReferenceException>(() => webshopController.CustomerId);
            Assert.Equal("customer header not set", exception.Message);
        }

        [Fact]
        public void HeaderFound()
        {
            //Arrange
            var httpcontext = new DefaultHttpContext();
            var webshopController = new WebshopController();


            //act
            httpcontext.Request.Headers["customer"] = "1234";      
            webshopController.ControllerContext = new ControllerContext { HttpContext = httpcontext };
           
            //Assert
            Assert.Equal("1234", webshopController.CustomerId);
        }
    }
}
