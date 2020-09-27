using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Tests.Utils;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private List<Category> categoriesToReturn;
        private List<Category> categoriesToReturnEmpty;
        private RepositoryMaster repositoryMaster;
        private VidlyContext context;
        private VidlyDbSet<Category> mockSet;
        private Mock<DbContext> mockDbContext;
        private CategoryRepository repository;
        private List<Category> emptyCategory;
        [TestInitialize]
        public void initVariables()
        {
            categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "New category",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Other category",
                },
                new Category()
                {
                    Id = 3,
                    Name = "And other category",
                },
                new Category()
                {
                    Id = 4,
                    Name = "And one more category",
                }
            };
            emptyCategory = new List<Category>();
            mockSet = new VidlyDbSet<Category>();
            mockDbContext = new Mock<DbContext>(MockBehavior.Strict);
        }
        [TestMethod]
        public void TestGetAllCategorysOk()
        {
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(categoriesToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestGetAllCategorysNull()
        {
            List<Category> emptyCategory = new List<Category>();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(emptyCategory).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            var result = repository.GetElements();
            Assert.IsTrue(emptyCategory.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistNot()
        {
            Category category = categoriesToReturn.First();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(emptyCategory).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            bool result = repository.ExistElement(category);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExist()
        {
            Category category = categoriesToReturn.First();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            bool result = repository.ExistElement(category);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int categoryId = categoriesToReturn.First().Id;
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            bool result = repository.ExistElement(categoryId);
            Assert.IsFalse(result);
        }
        // [TestMethod]
        // public void TestExistCategoryById()
        // {
        //     Category category = categoriesToReturn.First();
        //     mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new CategoryRepository(repositoryMaster);
        //     bool result = repository.ExistElement(category.Id);
        //     Assert.IsTrue(result);
        // }
        [TestMethod]
        public void TestExistCategory()
        {
            Category category = categoriesToReturn.First();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            bool result = repository.ExistElement(category);
            Assert.IsTrue(result);
        }
        // [TestMethod]
        // public void TestFind()
        // {
        //     Category category = categoriesToReturn.First();
        //     mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
        //     repositoryMaster = new RepositoryMaster(mockDbContext.Object);
        //     repository = new CategoryRepository(repositoryMaster);
        //     Category result = repository.Find(category.Id);
        //     Assert.AreEqual(result,category);
        // }

        [TestMethod]
        public void TestFindFail()
        {
            Category category = categoriesToReturn.First();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            Category result = repository.Find(category.Id + 1000);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Category category = categoriesToReturn.First();
            category.Name = "New name of category";
            string newName = category.Name;
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(categoriesToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            repository.Update(category);
            Assert.AreEqual(category.Name,newName);
        }
        [TestMethod]
        public void TestUpdateFail()
        {
            Category category = new Category(){Id = 13000};
            string newName = category.Name;
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(categoriesToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);
            repository.Update(category);
            // Exception exception = new ArgumentException();
            // Assert.IsInstanceOfType(result, typeof(Exception));
        }
    }
}