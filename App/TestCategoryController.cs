namespace WebApi.Test
{
    [TestClass]
    public class TestCategoryController
    {
        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            List<Category> categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "New category",
                    CategoryTouristPoints = new List<TouristPoint>(),
                },
                new Category()
                {
                    Id = 2,
                    Name = "Other category",
                    CategoryTouristPoints = new List<TouristPoint>(),
                }
            };
            var mock = new Mock<ICategoryLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            var controller = new CategoryController(mock.Object);
            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<Category>;
            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturn.SequenceEqual(categories));
        }
    }
}