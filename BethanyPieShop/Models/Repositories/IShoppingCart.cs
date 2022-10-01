using BethanyPieShop.Models.Domain;

namespace BethanyPieShop.Models.Repositories
{
    public interface IShoppingCart
    {
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
    }
}