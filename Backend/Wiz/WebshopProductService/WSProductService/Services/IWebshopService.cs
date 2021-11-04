using WSInformationService.Models;

namespace WSInformationService.Services
{
    public interface IWebshopService
    {
        WebshopInformationModel GetWebshopInformation(string customerid);
    }
}