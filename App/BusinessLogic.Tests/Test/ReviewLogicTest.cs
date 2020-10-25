using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Logics;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Moq;

namespace BusinessLogic.Tests.Test
{
    [TestClass]
    public class ReviewLogicTest
    {
        private  List<Review> reviewsToReturn;
        private  List<Review>  emptyReviews;
        private ReviewLogic reviewLogic;
        private Mock<IReviewRepository> mock;
        private Mock<IHouseRepository> mock2;
        private Mock<IStateRepository> mock3;
        private House houseId1;

        [TestInitialize]
        public void initVariables()
        {
            reviewsToReturn = new List<Review>()
            {
                new Review()
                {
                    Id = 1,
                    Name = "Review 1",
                    HouseId = 1,
                },
                new Review()
                {
                    Id = 2,
                    Name = "Review 2",
                    HouseId = 1,
                }
            };
            houseId1 = new House() {Id = 1, Avaible=true};
            emptyReviews = new List<Review>();
            mock = new Mock<IReviewRepository>(MockBehavior.Strict);
            mock2 = new Mock<IHouseRepository>(MockBehavior.Strict);
            mock2.Setup(c => c.Find(houseId1.Id)).Returns(houseId1);
            reviewLogic = new ReviewLogic(mock.Object,mock2.Object);
        }
        [TestMethod]
        public void TestDeleteById()
        {
            int lengthTouristPoint = reviewsToReturn.Count;
            mock.Setup(m => m.Delete(reviewsToReturn.First().Id));

            reviewLogic.Delete(reviewsToReturn.First().Id);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestDelete()
        {
            int lengthRegions = reviewsToReturn.Count;
            mock.Setup(m => m.GetElements()).Returns(reviewsToReturn);
            foreach (Review t in reviewsToReturn)
            {
                mock.Setup(m => m.Delete(t.Id));
            }

            reviewLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestDeleteEmpty()
        {
            mock.Setup(m => m.GetElements()).Returns(emptyReviews);

            reviewLogic.Delete();

            mock.VerifyAll();
        }
        [TestMethod]
        public void GetAll()
        {
            mock.Setup(m => m.GetElements()).Returns(reviewsToReturn);

            var result = reviewLogic.GetAll();

            Assert.IsTrue(result.SequenceEqual(reviewsToReturn));
        }
        [TestMethod]
        public void GetByTestOk()
        {
            Review review = reviewsToReturn.First();
            mock.Setup(m => m.Find(review.Id)).Returns(review);

            var result = reviewLogic.GetBy(review.Id);

            Assert.AreEqual(result,review);
        }
        [TestMethod]
        public void TestGetByFail()
        {
            Review review = reviewsToReturn.First();
            Review empty = null;
            mock.Setup(m => m.Find(review.Id)).Returns(empty);

            var result = reviewLogic.GetBy(review.Id);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestAddOk()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "nombre",
                HouseId = 1,
                Score = 1
            };
            Review review = reviewModel.ToEntity();
            mock.Setup(m => m.Add(review)).Returns(review);
            mock2.Setup(m => m.ExistElement(review.HouseId)).Returns(true);

            Review result = reviewLogic.Add(review);

            Assert.AreEqual(review, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddNullHouseId()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "nombre",
                HouseId = 0
            };
            Review review = reviewModel.ToEntity();
            mock2.Setup(m => m.ExistElement(review.HouseId)).Returns(false);

            var result = reviewLogic.Add(review);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestUpdateOk ()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "new name",
                HouseId = 1
            };
            Review review = reviewModel.ToEntity();
            int id  = review.Id;
            mock.Setup(m => m.Update(review.Id,review));
            mock.Setup(m => m.Find(review.Id)).Returns(review);
            mock2.Setup(m => m.ExistElement(review.HouseId)).Returns(true);
            mock2.Setup(m => m.Find(review.HouseId)).Returns(houseId1);

            Review result = reviewLogic.Update(id, review);

            Assert.AreEqual(result, review);
        }
        [TestMethod]
        public void TestUpdateOkNoHouseId ()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "new name",
                HouseId = 0,
                Score = 1,
            };
            Review review = reviewModel.ToEntity();
            int id  = review.Id;
            mock.Setup(m => m.Update(review.Id,review));
            mock.Setup(m => m.Find(review.Id)).Returns(review);
            mock2.Setup(m => m.ExistElement(review.HouseId)).Returns(true);
            mock2.Setup(m => m.Find(review.HouseId)).Returns(houseId1);

            Review result = reviewLogic.Update(id, review);

            Assert.AreEqual(result, review);
        }
        [TestMethod]
        public void TestUpdateOkScore ()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "new name",
                HouseId = 1,
                Score = 0,
            };
            Review review = reviewModel.ToEntity();
            int id  = review.Id;
            mock.Setup(m => m.Update(review.Id,review));
            mock.Setup(m => m.Find(review.Id)).Returns(review);
            mock2.Setup(m => m.ExistElement(review.HouseId)).Returns(true);
            mock2.Setup(m => m.Find(review.HouseId)).Returns(houseId1);

            Review result = reviewLogic.Update(id, review);

            Assert.AreEqual(result, review);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateNullHouseId()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "nombre",
                HouseId = 12
            };
            Review review = reviewModel.ToEntity();
            mock2.Setup(m => m.ExistElement(review.HouseId)).Returns(false);

            reviewLogic.Update(review.Id,review);

            mock.VerifyAll();
        }
        [TestMethod]
        public void TestExistOk()
        {
            Review review = reviewsToReturn.First();
            mock.Setup(m => m.ExistElement(review)).Returns(true);

            var result = reviewLogic.Exist(review);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNotExistOk()
        {
            Review review = reviewsToReturn.First();
            mock.Setup(m => m.ExistElement(review)).Returns(false);

            var result = reviewLogic.Exist(review);

            Assert.IsFalse(result);
        }
    }
}