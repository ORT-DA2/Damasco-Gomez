using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Model.Out
{
    [ExcludeFromCodeCoverage]
    public class ReviewDetailModel
    {
        public int Id {get; private set; }
        public string Name {get; private set;}
        public string Comment {get; private set;}
        public int HouseId {get; private set;}
        public HouseBasicModel House {get; private set;}
        public int Score {get; private set;}
        public ReviewDetailModel(Review review)
        {
            this.Id = review.Id;
            this.Name = review.Name;
            this.Comment = review.Comment;
            this.HouseId = review.HouseId;
            this.House = new HouseBasicModel(review.House);
            this.Score = review.Score;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is ReviewDetailModel review)
            {
                result = this.Id == review.Id ;
            }
            return result;
        }
    }
}