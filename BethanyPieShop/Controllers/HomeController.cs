using BethanyPieShop.Models.Repositories;
using BethanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var piesOfweek = _pieRepository.PiesOfTheWeek;
            var homeModel = new HomeViewModel(piesOfweek);
            return View(homeModel);
        }
    }
}