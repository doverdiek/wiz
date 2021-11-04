using WebshopOrderService.Models;

namespace WebshopOrderService.Services
{
    public interface IOrderService
    {
        void CreateOrder(Cart cart);
    }
}