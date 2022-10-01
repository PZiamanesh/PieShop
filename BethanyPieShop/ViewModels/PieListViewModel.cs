using BethanyPieShop.Models.Domain;

namespace BethanyPieShop.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string? CurrentCategory { get; set; }

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory = "All Pies")
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
    }
}
