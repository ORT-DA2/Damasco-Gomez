using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccess.Tests.Test
{
    [TestClass]
    public class ReviewRepositoryTest
    {
        private List<Review> reviewToReturn;
        private RepositoryMaster repositoryMaster;
        private DbContext context;
        private DbContextOptions options;
        private ReviewRepository repositoryReview;
        [TestInitialize]
        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<VidlyContext>().UseInMemoryDatabase(databaseName: "VidlyDBtest").Options;
            this.context = new VidlyContext(this.options);
            reviewToReturn = new List<Review>()
            {
                new Review()
                {
                    Id = 1,
                    Name = "Review 1",
                    HouseId = 1,
                    House = new House(){Id = 1},
                    Score = 3,
                    Comment = "one comment"
                },
                new Review()
                {
                    Id = 2,
                    Name = "Review 2",
                    HouseId = 100
                }
            };

            reviewToReturn.ForEach(m => this.context.Add(m));
            this.context.SaveChanges();
            repositoryMaster = new RepositoryMaster(context);
            repositoryReview = new ReviewRepository(repositoryMaster);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.context.Database.EnsureDeleted();
        }
        [TestMethod]
        public void TestAdd()
        {
            Review region = new Review(){Id = 123, Name="name new"};
            ReviewRepository repo = new ReviewRepository(this.repositoryMaster);
            int cantRepo = this.repositoryReview.GetElements().Count();

            repo.Add(region);

            Assert.AreEqual(repo.GetElements().Count(),cantRepo+1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailValidate()
        {
            Review region = new Review(){Id = 1, Name="name new"};

            repositoryReview.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFailExist()
        {
            Review region = reviewToReturn.First();

            repositoryReview.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateFailScoreNegative()
        {
            Review region = new Review(){Score = -2};

            repositoryReview.Add(region);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidateFail()
        {
            Review region = new Review(){Score = 11};

            repositoryReview.Add(region);
        }
        [TestMethod]
        public void TestGetAllReviewsOk()
        {
            var result = repositoryReview.GetElements();

            Assert.IsTrue(reviewToReturn.SequenceEqual(result));
        }
        [TestMethod]
        public void TestExistElement()
        {
            Review region = reviewToReturn.First();

            bool result = repositoryReview.ExistElement(region);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistElementFail()
        {
            Review region = new Review(){Id = 223 , Name="name"};

            bool result = repositoryReview.ExistElement(region);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExistWithIdFail()
        {
            int regionId = 234234234;

            bool result = repositoryReview.ExistElement(regionId);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestExistById()
        {
            Review region = reviewToReturn.First();

            bool result = repositoryReview.ExistElement(region.Id);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestExistByIdFail()
        {
            Review region = new Review(){Id=123423};

            bool result = repositoryReview.ExistElement(region.Id);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestFind()
        {
            Review region = reviewToReturn.First();

            Review result = repositoryReview.Find(region.Id);

            Assert.AreEqual(result,region);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFindFail()
        {
            Review region = new Review(){Id=232323};

            Review result = repositoryReview.Find(region.Id);
        }
        [TestMethod]
        public void TestUpdate()
        {
            Review region = reviewToReturn.First();
            region.Name = "New name of region";
            string newName = region.Name;

            repositoryReview.Update(region.Id, region);

            Assert.AreEqual(region.Name, newName);
        }
        [TestMethod]
        public void TestDelete()
        {
            Review region = reviewToReturn.First();
            int repoCount = this.repositoryReview.GetElements().Count();

            repositoryReview.Delete(region);

            Assert.AreEqual(repoCount - 1 , repositoryReview.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteFailExist()
        {
            Review region = new Review(){Id = 2342342};

            repositoryReview.Delete(region);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            Review region = reviewToReturn.First();
            int repoCount = this.repositoryReview.GetElements().Count();

            repositoryReview.Delete(region.Id);

            Assert.AreEqual(repoCount - 1 , repositoryReview.GetElements().Count());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDeleteByIdFailExist()
        {
            int id = 23123123;

            repositoryReview.Delete(id);
        }
    }
}