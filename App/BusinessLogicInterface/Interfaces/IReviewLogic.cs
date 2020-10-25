using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface
{
    public interface IReviewLogic
    {
        IEnumerable<Review> GetAll();
        IEnumerable<Review> GetByHouseId(int houseId);
        Review GetBy(int id);
        Review Add(Review element);
        Review Update(int id, Review element);
        void Delete(int id);
        void Delete();
        bool Exist(Review element);
    }
}