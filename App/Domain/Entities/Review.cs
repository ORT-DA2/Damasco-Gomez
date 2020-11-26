using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class Review
    {
        public int Id {get; set;}
        public int HouseId {get; set;}
        public virtual House House {get; set;}
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
        public void Update(Review element)
        {
            if(element.Name != null) this.Name = element.Name;
            if(element.HouseId > 0 ) this.HouseId = element.HouseId;
            if(element.Score > 0 ) this.Score = element.Score;
            if(element.Comment != null) this.Comment = element.Comment;
        }
        public bool IsEmpty()
        {
            bool nameNull = Name == null;
            bool scoreZero = Score == 0;
            bool commentNull = Comment == null;
            return nameNull && scoreZero && commentNull ;
        }
    }
}