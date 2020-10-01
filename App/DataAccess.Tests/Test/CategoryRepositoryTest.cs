using System;
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
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private CategoryRepository repository;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            categoriesToReturn = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Category 1",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Category 2",
                }
            };

            categoriesToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repository = new CategoryRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            Category category = new Category(){Id = 123, Name="name new"};
            CategoryRepository repo = new CategoryRepository(this.repositoryMaster);
            int cantRepo = this.repository.GetElements().Count();

            repo.Add(category);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Category category = new Category(){Id = 1, Name="name new"};

            repository.Add(category);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Category category = categoriesToReturn.First();
            ArgumentException exception = new ArgumentException();

            repository.Add(category);
        }
        [TestMethod]
        public void TestGetAllCategorysOk()
        {
            var result = repository.GetElements();

            Assert.IsTrue(categoriesToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Category category = categoriesToReturn.First();

            bool result = repository.ExistElement(category);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Category category = new Category(){Id = 223 , Name="name"};

            bool result = repository.ExistElement(category);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int categoryId = 234234234;

            bool result = repository.ExistElement(categoryId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Category category = categoriesToReturn.First();

            bool result = repository.ExistElement(category.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Category category = new Category(){Id=123423};

            bool result = repository.ExistElement(category.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Category category = categoriesToReturn.First();

            Category result = repository.Find(category.Id);

            Assert.AreEqual(result,category);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindFail()
        {
            Category category = new Category(){Id=232323};

            Category result = repository.Find(category.Id);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Category category = categoriesToReturn.First();
            // category.Name = "New name of category";
            // string newName = category.Name;

            // repository.Update(category);

            // Assert.AreEqual(category.Name,newName);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            // Category category = new Category(){Id = 13000};
            // string newName = category.Name;

            //repository.Update(category);
        }
        [TestMethod]
        public void TestDelete()
        {
            Category category = categoriesToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(category);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            Category category = categoriesToReturn.First();
            int lengthCategorys = categoriesToReturn.Count();

            repository.Delete(category);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Category category = categoriesToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(category.Id);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repository.Delete(id);
        }
    }
}