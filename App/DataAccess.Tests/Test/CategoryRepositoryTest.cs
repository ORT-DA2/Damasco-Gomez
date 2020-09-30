using System;
using System.Collections.Generic;
using System.Linq;
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
        private RepositoryMaster repositoryMaster;
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
        public void TestAdd()
        {
            Category category = new Category(){Id = 123, Name="name new"};
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            int categories = categoriesToReturn.Count();
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            var result = repository.Add(category);

            Assert.AreEqual(result , category);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Category category = new Category(){Id = 123, Name=""};
            int categoryLenght = categoriesToReturn.Count() ;
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Add(category);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Category category = categoriesToReturn.First();
            ArgumentException exception = new ArgumentException();
            var _mockSet = mockSet.GetMockDbSet(categoriesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<Category>())).Throws(exception);
            mockDbContext.Setup(d => d.Set<Category>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Add(category);
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
        public void TestExistElement()
        {
            Category category = categoriesToReturn.First();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            bool result = repository.ExistElement(category);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Category category = categoriesToReturn.First();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(emptyCategory).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            bool result = repository.ExistElement(category);

            Assert.IsFalse(result);
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
        [TestMethod]
        public void TestExistById()
        {
            Category category = categoriesToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(categoriesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(category);
            mockDbContext.Setup(d => d.Set<Category>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            bool result = repository.ExistElement(category.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Category category = new Category(){Id=123423};
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            bool result = repository.ExistElement(category.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Category category = categoriesToReturn.First();
            var _mockSet = mockSet.GetMockDbSet(categoriesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(category);
            mockDbContext.Setup(d => d.Set<Category>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            Category result = repository.Find(category.Id);

            Assert.AreEqual(result,category);
        }

        [TestMethod]
        public void TestFindFail()
        {
            Category category = new Category(){Id=232323};
            Category categoryNull = null;
            var _mockSet = mockSet.GetMockDbSet(categoriesToReturn);
            ArgumentException exception = new ArgumentException();
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(categoryNull);
            mockDbContext.Setup(d => d.Set<Category>()).Returns(_mockSet.Object);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            Category result = repository.Find(category.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Category category = categoriesToReturn.First();
            category.Name = "New name of category";
            string newName = category.Name;
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Update(category);

            Assert.AreEqual(category.Name,newName);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            Category category = new Category(){Id = 13000, Name="new name"};
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(categoriesToReturn.First().Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            //repository.Update(category);
        }
        [TestMethod]
        public void TestDelete()
        {
            Category category = categoriesToReturn.First();
            int lengthCategorys = categoriesToReturn.Count();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            mockDbContext.Setup(d => d.Remove(category));
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Delete(category);
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Category category = categoriesToReturn.First();
            int lengthCategorys = categoriesToReturn.Count();
            mockDbContext.Setup(d => d.Set<Category>()).Returns(mockSet.GetMockDbSet(categoriesToReturn).Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Delete(category);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Category category = categoriesToReturn.First();
            int lengthCategorys = categoriesToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(categoriesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(category);
            mockDbContext.Setup(d => d.Set<Category>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Delete(category.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            Category category = categoriesToReturn.First();
            Category categoryNull = null;
            int lengthCategorys = categoriesToReturn.Count();
            var _mockSet = mockSet.GetMockDbSet(categoriesToReturn);
            _mockSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns(categoryNull);
            mockDbContext.Setup(d => d.Set<Category>()).Returns(_mockSet.Object);
            mockDbContext.Setup(d => d.SaveChanges()).Returns(category.Id);
            repositoryMaster = new RepositoryMaster(mockDbContext.Object);
            repository = new CategoryRepository(repositoryMaster);

            repository.Delete(category.Id);
        }
    }
}