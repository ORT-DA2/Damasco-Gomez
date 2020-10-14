using System.Collections.Generic;
using Domain.Entities;
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

            category.Update(newCategory);

            Assert.AreEqual(newCategory.Name, category.Name);
        }
        [TestMethod]
        public void TestUpdateNameEmpty()
        {
            string nameShouldBe = category.Name;
            Category newCategory = new Category()
                {
                    Name = null,
                };

            category.Update(newCategory);

            Assert.AreEqual(nameShouldBe, category.Name);
        }
        [TestMethod]
        public void TestCategoryTourist()
        {
            CategoryTouristPoint newCate = new CategoryTouristPoint();
            Category newCategory = new Category()
            {
                Name = null,
                CategoryTouristPoints = new List<CategoryTouristPoint>() { newCate },
            };

            category.Update( newCategory);

            Assert.IsNull(category.CategoryTouristPoints);
        }
        [TestMethod]
        public void TestId()
        {
            int id = 1;
            Category newCategory = new Category()
            {
                Id = id,
                Name = null,
            };

            category.Update( newCategory);

            Assert.AreEqual(newCategory.Id, id);
        }
        [TestMethod]
        public void TestIsEmpty()
        {
            Category newCategory = new Category()
            {
                Name = null,
            };
            
            bool empty = newCategory.IsEmpty();

            Assert.IsTrue(empty);
        }
        [TestMethod]
        public void TestIsEmptyWithName()
        {
            Category newCategory = new Category()
            {
                Name = "name",
            };
            
            bool empty = newCategory.IsEmpty();

            Assert.IsFalse(empty);
        }
    }
}