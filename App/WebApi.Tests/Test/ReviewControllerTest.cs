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
        private Review reviewId1;
        private Mock<IReviewLogic> mock;
        private ReviewController controller ;
        [TestInitialize]
        public void initVariables()
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
            reviewId1 = reviewsToReturn.First();
            mock = new Mock<IReviewLogic>(MockBehavior.Strict);
            controller = new ReviewController(mock.Object);
        }
        [TestMethod]
        public void TestGetAllReviewsOk()
        {
            mock.Setup(m => m.GetAll()).Returns(reviewsToReturn);
            IEnumerable<ReviewBasicModel> reviewModels = reviewsToReturn.Select(m => new ReviewBasicModel(m));

            var result = controller.GetReviewsBy(0);

            var okResult = result as OkObjectResult;
            var reviews = okResult.Value as IEnumerable<ReviewBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(reviewModels.SequenceEqual(reviews));
        }

        [TestMethod]
        public void TestGetAllReviewsVacia()
        {
            IEnumerable<ReviewBasicModel> basicModelList = new List<ReviewBasicModel>(){};
            mock.Setup(m => m.GetAll()).Returns(reviewsToReturnEmpty);

            var result = controller.GetReviewsBy(0);

            var okResult = result as OkObjectResult;
            var reviews = okResult.Value as IEnumerable<ReviewBasicModel>;
            mock.VerifyAll();
            Assert.IsTrue(basicModelList.SequenceEqual(reviews));
        }
        [TestMethod]
        public void TestGetByOk()
        {
            int id = 1;
            mock.Setup(m => m.GetBy(id)).Returns(reviewId1);
            ReviewDetailModel reviewDetailModel = new ReviewDetailModel(reviewId1);

            var result = controller.GetBy(id);

            var okResult = result as OkObjectResult;
            var reviews = okResult.Value as ReviewDetailModel;
            mock.VerifyAll();
            Assert.IsTrue(reviews.Equals(reviewDetailModel));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetByNotFound()
        {
            int id = 4;
            ArgumentException exist = new ArgumentException();
            mock.Setup(m => m.GetBy(id)).Throws(exist);

            var result = controller.GetBy(id);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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
            mock.Setup(m => m.Add(reviewModel.ToEntity())).Returns(reviewModel.ToEntity());
            ReviewBasicModel reviewBasic = new ReviewBasicModel(review);

            var result = controller.Post(reviewModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual("GetReview", okResult.RouteName);
            Assert.AreEqual(okResult.Value,reviewBasic);
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
            mock.Setup(p => p.Add(reviewModel.ToEntity())).Throws(exist);

            var result = controller.Post(reviewModel);

            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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
            mock.Setup(p => p.Add(reviewModel.ToEntity())).Throws(exist);

            var result = controller.Post(reviewModel);

            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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
            mock.Setup(p => p.Add(reviewModel.ToEntity())).Throws(exist);

            var result = controller.Post(reviewModel);

            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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
            mock.Setup(m => m.Update(review.Id,review)).Returns(review);
            ReviewBasicModel reviewBasic = new ReviewBasicModel(review);

            var result = controller.Put(review.Id, reviewModel);

            var okResult = result as CreatedAtRouteResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual("GetReview", okResult.RouteName);
            Assert.AreEqual(okResult.Value, reviewBasic);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPutFailValidate()
        {
            ReviewModel reviewModel = new ReviewModel();
            Review review = reviewModel.ToEntity();
            Exception exist = new ArgumentException();
            mock.Setup(p => p.Update(review.Id,review)).Throws(exist);

            var result = controller.Put(review.Id, reviewModel);

            mock.VerifyAll();
            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
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
            mock.Setup(p => p.Update(review.Id,review)).Throws(exist);

            var result = controller.Put(review.Id,reviewModel);

            //Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        [TestMethod]
        public void TestDeleteWithId()
        {
            Review review = reviewsToReturn.First();
            mock.Setup(m => m.GetBy(review.Id)).Returns(review);
            mock.Setup(mock=> mock.Delete(review.Id));

            var result = controller.Delete(review.Id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteWithIdNotFound()
        {
            Review review = reviewsToReturn.First();
            Review reviewNull = null;
            mock.Setup(m => m.GetBy(review.Id)).Returns(reviewNull);
            mock.Setup(mock=> mock.Delete(review.Id));

            var result = controller.Delete(review.Id);

            //Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestDelete()
        {
            mock.Setup(mock=> mock.Delete());

            var result = controller.Delete();

            Assert.IsNotNull(result);
        }
    }
}