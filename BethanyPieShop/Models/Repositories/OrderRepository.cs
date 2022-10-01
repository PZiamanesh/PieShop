using BethanyPieShop.Models.Context;
using BethanyPieShop.Models.Domain;

namespace BethanyPieShop.Models.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly PieShopDbContext _bethanysPieShopDbContext;
    private readonly IShoppingCart _shoppingCart;

    public OrderRepository(PieShopDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart)
    {
        _bethanysPieShopDbContext = bethanysPieShopDbContext;
        _shoppingCart = shoppingCart;
    }

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;

        List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

        order.OrderDetails = new List<OrderDetail>();

        //adding the order with its details

        foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Amount = shoppingCartItem.Amount,
                PieId = shoppingCartItem.Pie.PieId,
                Price = shoppingCartItem.Pie.Price
            };

            order.OrderDetails.Add(orderDetail);
        }

        _bethanysPieShopDbContext.Orders.Add(order);

        _bethanysPieShopDbContext.SaveChanges();
    }
}