using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Test
{
    [TestClass]
    public class ReviewControllerTest
    {
        private List<Review> reviewsToReturn;
        private List<Review> reviewsToReturnEmpty;
        private Review reviewWithId1;
        private Mock<IReviewLogic> mockReviewLogic;
        private ReviewController controllerReview ;
        [TestInitialize]
        public void InitVariables()
        {
            reviewsToReturn = new List<Review>()
            {
                new Review()
                {
                    Id = 1,
                    Name = "New review",
                    Comment = "comment",
                    HouseId = 1,
                    House = new House(){ Id=1, Name="house in review"},
                    Score = 1,
                },
                new Review()
                {
                    Id = 2,
                    Name = "Other review",
                    Comment = "comment",
                    HouseId = 1,
                    House = new House(){Id=1,Name="house in review"},
                    Score = 1,
                },
                new Review()
                {
                    Id = 3,
                    Name = "And other review",
                    Comment = "comment",
                    HouseId = 1,
                    House = new House(){Id=1,Name="house in review"},
                    Score = 1,
                },
                new Review()
                {
                    Id = 4,
                    Name = "And one more review",
                    Comment = "comment",
                    HouseId = 1,
                    House = new House(){Id=1,Name="house in review"},
                    Score = 3,
                }
            };
            reviewsToReturnEmpty = new List<Review>();
            reviewWithId1 = reviewsToReturn.First();
            mockReviewLogic = new Mock<IReviewLogic>(MockBehavior.Strict);
            controllerReview = new ReviewController(mockReviewLogic.Object);
        }
        [TestMethod]
        public void TestGetAllReviewsOk()
        {
            mockReviewLogic.Setup(m => m.GetAll()).Returns(reviewsToReturn);
            IEnumerable<ReviewBasicModel> reviewModels = reviewsToReturn.Select(m => new ReviewBasicModel(m));

            var result = controllerReview.GetReviewsBy(0);

            var okResult = result as OkObjectResult;
            var reviews = okResult.Value as IEnumerable<ReviewBasicModel>;
            mockReviewLogic.VerifyAll();
            Assert.IsTrue(reviewModels.SequenceEqual(reviews));
        }

        [TestMethod]
        public void TestGetAllReviewsVacia()
        {
            IEnumerable<ReviewBasicModel> basicModelList = new List<ReviewBasicModel>(){};
            mockReviewLogic.Setup(m => m.GetAll()).Returns(reviewsToReturnEmpty);

            var result = controllerReview.GetReviewsBy(0);

            var okResult = result as OkObjectResult;
            var reviews = okResult.Value as IEnumerable<ReviewBasicModel>;
            mockReviewLogic.VerifyAll();
            Assert.IsTrue(basicModelList.SequenceEqual(reviews));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mockReviewLogic.Setup(m => m.GetBy(id)).Returns(reviewWithId1);
            ReviewDetailModel reviewDetailModel = new ReviewDetailModel(reviewWithId1);

            var result = controllerReview.GetBy(id);

            var okResult = result as OkObjectResult;
            var reviews = okResult.Value as ReviewDetailModel;
            mockReviewLogic.VerifyAll();
            Assert.IsTrue(reviews.Equals(reviewDetailModel));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mockReviewLogic.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controllerReview.GetBy(id);

            mockReviewLogic.VerifyAll();
        }
        [TestMethod]
        public void TestPostOk()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "Name Review",
                Comment = "Comment ",
                HouseId = 1,
                Score = 1,
            };
            Review review = reviewModel.ToEntity();
            mockReviewLogic.Setup(m => m.Add(reviewModel.ToEntity())).Returns(reviewModel.ToEntity());
            ReviewBasicModel reviewBasic = new ReviewBasicModel(review);

            var result = controllerReview.Post(reviewModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult);
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestPostFailSameReview()
        {
            Exception exist = new AggregateException();
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "Name Review",
                Comment = "Comment ",
                HouseId = 1,
                Score = 1,
            };
            mockReviewLogic.Setup(p => p.Add(reviewModel.ToEntity())).Throws(exist);

            var result = controllerReview.Post(reviewModel);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPostFailValidation()
        {
            Exception exist = new ArgumentException();
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "Name Review",
                Comment = "Comment ",
                HouseId = 1,
                Score = 1,
            };
            mockReviewLogic.Setup(p => p.Add(reviewModel.ToEntity())).Throws(exist);

            var result = controllerReview.Post(reviewModel);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostFailServer()
        {
            Exception exist = new Exception();
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "Name Review",
                Comment = "Comment ",
                HouseId = 1,
                Score = 1,
            };
            mockReviewLogic.Setup(p => p.Add(reviewModel.ToEntity())).Throws(exist);

            var result = controllerReview.Post(reviewModel);
        }
        [TestMethod]
        public void TestPutOk()
        {
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "Name Review",
                Comment = "Comment ",
                HouseId = 1,
                Score = 1,
            };
            Review review = reviewModel.ToEntity();
            review.House = new House(){Id = 1};
            mockReviewLogic.Setup(m => m.Update(review.Id,review)).Returns(review);
            ReviewBasicModel reviewBasic = new ReviewBasicModel(review);

            var result = controllerReview.Put(review.Id, reviewModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult.Value);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            ReviewModel reviewModel = new ReviewModel();
            Review review = reviewModel.ToEntity();
            Exception exist = new ArgumentException();
            mockReviewLogic.Setup(p => p.Update(review.Id,review)).Throws(exist);

            var result = controllerReview.Put(review.Id, reviewModel);

            mockReviewLogic.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPutFailServer()
        {
            Exception exist = new Exception();
            ReviewModel reviewModel = new ReviewModel()
            {
                Name = "Name Review",
                Comment = "Comment ",
                HouseId = 1,
                Score = 1,
            };
            Review review = reviewModel.ToEntity();
            mockReviewLogic.Setup(p => p.Update(review.Id,review)).Throws(exist);

            var result = controllerReview.Put(review.Id,reviewModel);
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Review review = reviewsToReturn.First();
            mockReviewLogic.Setup(m => m.GetBy(review.Id)).Returns(review);
            mockReviewLogic.Setup(mockReviewLogic=> mockReviewLogic.Delete(review.Id));

            var result = controllerReview.Delete(review.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Review review = reviewsToReturn.First();
            Review reviewNull = null;
            mockReviewLogic.Setup(m => m.GetBy(review.Id)).Returns(reviewNull);
            mockReviewLogic.Setup(mockReviewLogic=> mockReviewLogic.Delete(review.Id));

            var result = controllerReview.Delete(review.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            mockReviewLogic.Setup(mockReviewLogic=> mockReviewLogic.Delete());

            var result = controllerReview.Delete();

            Assert.IsNotNull(result);
        }
    }
}