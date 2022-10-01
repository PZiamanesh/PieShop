using BethanyPieShop.Controllers;
using BethanyPieShop.ViewModels;
using BethanyPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_WithoutCategoryName_ReturnAllPies()
        {
            // arrange
            var pieRepoMock = RepositoryMocks.GetPieRepository();
            var categoryRepoMock = RepositoryMocks.GetCategoryRepository();
            var pieController = new PieController(pieRepoMock.Object, categoryRepoMock.Object);

            // act
            var result = pieController.List("");

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.Model);
        }
    }
}
