using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAuth;
using WSInformationService.Models;
using WSInformationService.Services;

namespace WSProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebshopInformationController : WebshopController
    {
        private readonly IWebshopService webshopService;
        public WebshopInformationController(IWebshopService webshopService)
        {
            this.webshopService = webshopService;
        }

        [HttpGet]
        public WebshopInformationModel RetrieveWebshopData()
        {
            return webshopService.GetWebshopInformation(CustomerId);
        }
    }
}
