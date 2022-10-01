using BethanyPieShop.Models.Domain;
using BethanyPieShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "no item was added, please choose some pies.");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            ViewBag.OrderNotValid = true;
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutComplete = "Thank you for ordering our pies! we will deliver them for you as soon as possible!";
            return View();
        }
    }
}
