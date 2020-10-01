namespace Domain.Entities
{
    public class CategoryTouristPoint
    {
        public int Id {get; set;}

        public int CategoryId {get; set;}
        public Category Category {get; set;}
        public int TouristPointId {get; set;}
        public TouristPoint TouristPoint {get; set;}

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