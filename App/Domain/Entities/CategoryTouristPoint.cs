namespace Domain.Entities
{
    public class CategoryTouristPoint
    {
        public int Id {get; set;}

        public int CategoryId {get; set;}
        public virtual Category Category {get; set;}
        public int TouristPointId {get; set;}
        public virtual TouristPoint TouristPoint {get; set;}

        public CategoryTouristPoint(){}

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is CategoryTouristPoint category)
            {
                result = this.Id == category.Id;
            }
            return result;
        }
    }
}