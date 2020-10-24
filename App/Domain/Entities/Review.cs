using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Review
    {
        public int Id {get; set;}
        public int HouseId {get; set;}
        public House House {get; set;}
        public string Name {get; set;}
        public int Score {get; set;}
        public string Comment {get; set;}
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is Review review)
            {
                result = this.Id == review.Id ;
            }
            return result;
        }
    }
}