using BethanyPieShop.Models.Domain;

namespace BethanyPieShop.Models.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}