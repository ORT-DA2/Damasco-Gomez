using System;
using Domain.Entities;

namespace Model.In
{
    public class ReviewModel
    {
        public int HouseId {get; set;}
        public string Name {get; set;}
        public int Score {get; set;}
        public string Comment {get; set;}
        public Review ToEntity()
        {
            Review review = new Review()
            {
                Name = this.Name,
                Score = this.Score,
                HouseId = this.HouseId,
                Comment = this.Comment,
            };
            if(review.IsEmpty()) throw new ArgumentException("No values");
            return review;
        }
    }
}