using BethanyPieShop.Models.Domain;
using BethanyPieShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _pieRepository.AllPies.OrderBy(p => p.Name);
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var selectedPie = _pieRepository.GetPieById(id);
            if (selectedPie is null)
            {
                return NotFound();
            }

            return Ok(selectedPie);
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (string.IsNullOrEmpty(searchQuery))
            {
                return NotFound();
            }

            pies = _pieRepository.SearchPies(searchQuery);
            //return new JsonResult(pies);
            return Ok(pies);
        }
    }
}