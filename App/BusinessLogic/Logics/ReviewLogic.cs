using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class ReviewLogic
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IHouseRepository houseRepository;
        public ReviewLogic(IReviewRepository reviewRepository, IHouseRepository houseRepository)
        {
            this.reviewRepository = reviewRepository;
            this.houseRepository = houseRepository;
        }
        public void Delete()
        {
            foreach(Review review in this.reviewRepository.GetElements())
            {
                this.Delete(review.Id);
            }
        }
        public IEnumerable<Review> GetAll()
        {
            return this.reviewRepository.GetElements();
        }
        public Review GetBy(int id)
        {
            return this.reviewRepository.Find(id);
        }
        public IEnumerable<Review> GetByHouseId(int houseId)
        {
            IEnumerable<Review> reviews = this.reviewRepository.GetElements()
                .Where(r => r.HouseId == houseId);
            return reviews;
        }
        public Review Add(Review review)
        {
            ValidateHouse(review.HouseId);
            Review reviewAdded = this.reviewRepository.Add(review);
            return reviewAdded;
        }
        public Review Update(int id, Review review)
        {
            if(review.HouseId > 0) ValidateHouse(review.HouseId);
            Review reviewBD = this.reviewRepository.Find(id);
            reviewBD.Update(review);
            this.reviewRepository.Update(id, reviewBD);
            return reviewBD;
        }
        public void Delete(int id)
        {
            this.reviewRepository.Delete(id);
        }
        public bool Exist(Review Review)
        {
            return this.reviewRepository.ExistElement(Review);
        }
        public void ValidateHouse(int houseId)
        {
            if (!this.houseRepository.ExistElement(houseId))
            {
                throw new ArgumentException("There is no House with id : " + houseId);
            }
        }
    }
}