using BethanyPieShop.Models.Context;
using BethanyPieShop.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanyPieShop.Models.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext _pieShopDbContext;

        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            _pieShopDbContext = pieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return _pieShopDbContext.Pies.Include(c => c.Category); }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get { return _pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek); }
        }

        public Pie? GetPieById(int id)
        {
            return _pieShopDbContext.Pies.FirstOrDefault(p => p.PieId == id);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _pieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}