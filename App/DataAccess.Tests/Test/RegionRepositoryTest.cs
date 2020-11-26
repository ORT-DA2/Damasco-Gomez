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
        private RegionRepository repositoryRegion;
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
            repositoryRegion = new RegionRepository(repositoryMaster);
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
            int cantRepo = this.repositoryRegion.GetElements().Count();

            repo.Add(region);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Region region = new Region(){Id = 1, Name="name new"};

            repositoryRegion.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Region region = regionsToReturn.First();

            repositoryRegion.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateFail()
        {
            Region region = new Region(){Name = ""};

            repositoryRegion.Add(region);
        }
        [TestMethod]
        public void TestGetAllRegionsOk()
        {
            var result = repositoryRegion.GetElements();

            Assert.IsTrue(regionsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Region region = regionsToReturn.First();

            bool result = repositoryRegion.ExistElement(region);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Region region = new Region(){Id = 223 , Name="name"};

            bool result = repositoryRegion.ExistElement(region);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int regionId = 234234234;

            bool result = repositoryRegion.ExistElement(regionId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Region region = regionsToReturn.First();

            bool result = repositoryRegion.ExistElement(region.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Region region = new Region(){Id=123423};

            bool result = repositoryRegion.ExistElement(region.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Region region = regionsToReturn.First();

            Region result = repositoryRegion.Find(region.Id);

            Assert.AreEqual(result,region);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindFail()
        {
            Region region = new Region(){Id=232323};

            Region result = repositoryRegion.Find(region.Id);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Region region = regionsToReturn.First();
            region.Name = "New name of region";
            string newName = region.Name;

            repositoryRegion.Update(region.Id, region);

            Assert.AreEqual(region.Name, newName);
        }
        [TestMethod]
        public void TestDelete()
        {
            Region region = regionsToReturn.First();
            int repoCount = this.repositoryRegion.GetElements().Count();

            repositoryRegion.Delete(region);

            Assert.AreEqual(repoCount - 1 , repositoryRegion.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteFailExist()
        {
            Region region = new Region(){Id = 2342342};

            repositoryRegion.Delete(region);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Region region = regionsToReturn.First();
            int repoCount = this.repositoryRegion.GetElements().Count();

            repositoryRegion.Delete(region.Id);

            Assert.AreEqual(repoCount - 1 , repositoryRegion.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repositoryRegion.Delete(id);
        }
    }
}