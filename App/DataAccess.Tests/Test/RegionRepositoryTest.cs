using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests
{
    [TestClass]
    public class RegionRepositoryTest
    {
        private List<Region> regionsToReturn;
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private RegionRepository repository;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            regionsToReturn = new List<Region>()
            {
                new Region()
                {
                    Id = 1,
                    Name = "Region 1",
                },
                new Region()
                {
                    Id = 2,
                    Name = "Region 2",
                }
            };

            regionsToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repository = new RegionRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            Region region = new Region(){Id = 123, Name="name new"};
            RegionRepository repo = new RegionRepository(this.repositoryMaster);
            int cantRepo = this.repository.GetElements().Count();

            repo.Add(region);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Region region = new Region(){Id = 1, Name="name new"};

            repository.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Region region = regionsToReturn.First();

            repository.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateFail()
        {
            Region region = new Region(){Name = ""};

            repository.Add(region);
        }
        [TestMethod]
        public void TestGetAllRegionsOk()
        {
            var result = repository.GetElements();

            Assert.IsTrue(regionsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Region region = regionsToReturn.First();

            bool result = repository.ExistElement(region);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Region region = new Region(){Id = 223 , Name="name"};

            bool result = repository.ExistElement(region);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int regionId = 234234234;

            bool result = repository.ExistElement(regionId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Region region = regionsToReturn.First();

            bool result = repository.ExistElement(region.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Region region = new Region(){Id=123423};

            bool result = repository.ExistElement(region.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Region region = regionsToReturn.First();

            Region result = repository.Find(region.Id);

            Assert.AreEqual(result,region);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindFail()
        {
            Region region = new Region(){Id=232323};

            Region result = repository.Find(region.Id);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Region region = regionsToReturn.First();
            region.Name = "New name of region";
            string newName = region.Name;

            repository.Update(region.Id, region);

            Assert.AreEqual(region.Name, newName);
        }
        [TestMethod]
        public void TestDelete()
        {
            Region region = regionsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(region);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteFailExist()
        {
            Region region = new Region(){Id = 2342342};

            repository.Delete(region);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Region region = regionsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(region.Id);

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