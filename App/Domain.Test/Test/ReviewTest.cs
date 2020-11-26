using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Test
{
    [TestClass]
    public class ReviewTest
    {
        public Review review;
        [TestInitialize]
        public void SetUp()
        {
            review = new Review()
                {
                    Id = 2,
                    Name = "Other review",
                    HouseId = 0,
                    Score = 1,
                    Comment = "one comment"
                };
        }
        [TestMethod]
        public void TestUpdateName()
        {
            Review newBooking = new Review()
                {
                    Name = "new name review",
                    Comment = null,
                    HouseId = 0,
                    Score = 1,
                };

            review.Update(newBooking);

            Assert.AreEqual(newBooking.Name, review.Name);
        }
        [TestMethod]
        public void TestUpdateComment()
        {
            Review newBooking = new Review()
                {
                    Name = null,
                    Comment = "new mail",
                    HouseId = 0,
                    Score = 1,
                };

            review.Update(newBooking);

            Assert.AreEqual(newBooking.Comment, review.Comment);
        }
        [TestMethod]
        public void TestUpdateHouseId()
        {
            Review newBooking = new Review()
                {
                    Name = null,
                    Comment = null,
                    HouseId = 120,
                    Score = 1
                };

            review.Update(newBooking);

            Assert.AreEqual(newBooking.HouseId, review.HouseId);
        }
        [TestMethod]
        public void TestUpdateScore()
        {
            int scoreNew = 2;
            Review newBooking = new Review()
            {
                Name = null,
                Comment = null,
                HouseId = 0,
                Score = scoreNew,
            };

            review.Update(newBooking);

            Assert.AreEqual(scoreNew, newBooking.Score);
        }
        [TestMethod]
        public void TestId()
        {
            int id = 1;

            Review newBooking = new Review()
            {
                Name = null,
                Comment = null,
                HouseId = 0,
                Id = 1
            };


            Assert.AreEqual(id, newBooking.Id);
        }
        [TestMethod]
        public void TestTouristPoint()
        {
            House house = new House();

            Review newBooking = new Review()
            {
                Name = null,
                Comment = null,
                HouseId = 0,
                House = house,
            };


            Assert.AreEqual(house, newBooking.House);
        }
        [TestMethod]
        public void TestIsEmpty()
        {
            Review newBooking = new Review()
            {
                Name = null,
                Comment = null,
                HouseId = 0,
                Score = 0
            };

            bool empty = newBooking.IsEmpty();

            Assert.IsTrue(empty);
        }
        [TestMethod]
        public void TestIsEmptyWithName()
        {
            Review newBooking = new Review()
            {
                Name = "name",
                Comment = null,
                HouseId = 0,
                Score = 0,
            };

            bool empty = newBooking.IsEmpty();

            Assert.IsFalse(empty);
        }
        [TestMethod]
        public void TestIsEmptyWithComment()
        {
            Review newBooking = new Review()
            {
                Name = null,
                Comment = "email",
                HouseId = 0,
                Score = 0,
            };

            bool empty = newBooking.IsEmpty();

            Assert.IsFalse(empty);
        }
        [TestMethod]
        public void TestIsEmptyWithHouseId()
        {
            Review newBooking = new Review()
            {
                Name = "Name",
                Comment = "Comment",
                HouseId = 1,
                Score = 3,
            };

            bool empty = newBooking.IsEmpty();

            Assert.IsFalse(empty);
        }
        [TestMethod]
        public void TestIsEmptyWithScore()
        {
            Review newBooking = new Review()
            {
                Name = null,
                Comment = null,
                HouseId = 0,
                Score = 10,
            };

            bool empty = newBooking.IsEmpty();

            Assert.IsFalse(empty);
        }
        [TestMethod]
        public void TestIsEmptyFalse()
        {
            Review newBooking = new Review()
            {
                Name = "Name",
                Comment = "Comment",
                HouseId = 1,
                Score = 10,
            };

            bool empty = newBooking.IsEmpty();

            Assert.IsFalse(empty);
        }
    }
}