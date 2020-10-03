using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class CategoryTest
    {
        public Category category;
        [TestInitialize]
        public void SetUp()
        {
            category = new Category()
                {
                    Id = 2,
                    Name = "Other category",
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            Category newCategory = new Category()
                {
                    Name = "new name category",
                };

            Category.Update(category,newCategory);

            Assert.AreEqual(newCategory.Name, category.Name);
        }
        [TestMethod]
        public void TestUpdateNameEmpty()
        {
            string nameShouldBe = category.Name;
            Category newCategory = new Category()
                {
                    Name = "",
                };

            Category.Update(category,newCategory);

            Assert.AreEqual(nameShouldBe, category.Name);
        }
    }
}