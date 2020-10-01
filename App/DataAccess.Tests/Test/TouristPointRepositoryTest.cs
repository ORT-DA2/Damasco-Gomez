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
    public class TouristPointRepositoryTest
    {
        private List<TouristPoint> touristPointsToReturn;
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private TouristPointRepository repository;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            touristPointsToReturn = new List<TouristPoint>()
            {
                new TouristPoint()
                {
                    Id = 1,
                    Name = "TouristPoint 1",
                    Description = "A description",
                },
                new TouristPoint()
                {
                    Id = 2,
                    Name = "TouristPoint 2",
                    Description = "A description",
                }
            };

            touristPointsToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repository = new TouristPointRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            TouristPoint touristPoint = new TouristPoint(){Id = 123, Name="name new",RegionId = 1};
            TouristPointRepository repo = new TouristPointRepository(this.repositoryMaster);
            int cantRepo = this.repository.GetElements().Count();

            repo.Add(touristPoint);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            TouristPoint touristPoint = new TouristPoint(){Id = 123, Name="name new",RegionId=0};

            repository.Add(touristPoint);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            ArgumentException exception = new ArgumentException();

            repository.Add(touristPoint);
        }
        [TestMethod]
        public void TestGetAllTouristPointsOk()
        {
            var result = repository.GetElements();

            Assert.IsTrue(touristPointsToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();

            bool result = repository.ExistElement(touristPoint);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            TouristPoint touristPoint = new TouristPoint(){Id = 223 , Name="name"};

            bool result = repository.ExistElement(touristPoint);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int touristPointId = 234234234;

            bool result = repository.ExistElement(touristPointId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();

            bool result = repository.ExistElement(touristPoint.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            TouristPoint touristPoint = new TouristPoint(){Id=123423};

            bool result = repository.ExistElement(touristPoint.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();

            TouristPoint result = repository.Find(touristPoint.Id);

            Assert.AreEqual(result,touristPoint);
        }

        [TestMethod]
        public void TestFindFail()
        {
            TouristPoint touristPoint = new TouristPoint(){Id=232323};

            TouristPoint result = repository.Find(touristPoint.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // TouristPoint touristPoint = touristPointsToReturn.First();
            // touristPoint.Name = "New name of touristPoint";
            // string newName = touristPoint.Name;

            // repository.Update(touristPoint);

            // Assert.AreEqual(touristPoint.Name,newName);
        }
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestUpdateFail()
        {
            // TouristPoint touristPoint = new TouristPoint(){Id = 13000};
            // string newName = touristPoint.Name;

            //repository.Update(touristPoint);
        }
        [TestMethod]
        public void TestDelete()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(touristPoint);

            Assert.AreEqual(repoCount - 1 , repository.GetElements().Count());
        }
        [TestMethod]
        public void TestDeleteFailExist()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            int lengthTouristPoints = touristPointsToReturn.Count();

            repository.Delete(touristPoint);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            TouristPoint touristPoint = touristPointsToReturn.First();
            int repoCount = this.repository.GetElements().Count();

            repository.Delete(touristPoint.Id);

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