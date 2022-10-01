using BethanyPieShop.Models.Domain;

namespace BethanyPieShop.Models.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; } 
    }
}
