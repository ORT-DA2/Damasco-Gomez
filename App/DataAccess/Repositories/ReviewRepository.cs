using System;
using DataAccessInterface.Repositories;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class ReviewRepository : AccessData<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Reviews;
        }
        protected override void Update(Review elementToUpdate, Review element)
        {
        }

        protected override void Validate(Review element)
        {
            if (element.Score > 10 || element.Score < 0) throw new ArgumentException("You need a score between 0 and 10");
        }
    }
}