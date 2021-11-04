using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSInformationService.Models;
using WSInformationService.Repos;

namespace WSInformationService.Services
{
    public class WebshopService : IWebshopService
    {
        private readonly IWebshopRepo webshopRepo;
        public WebshopService(IWebshopRepo webshopRepo)
        {
            this.webshopRepo = webshopRepo;
        }

        public WebshopInformationModel GetWebshopInformation(string customerid)
        {
            try
            {
                return new WebshopInformationModel
                {
                    Categories = webshopRepo.GetCategories(customerid),
                    Products = webshopRepo.GetProducts(customerid),
                    Title = webshopRepo.GetTitle(customerid)
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
