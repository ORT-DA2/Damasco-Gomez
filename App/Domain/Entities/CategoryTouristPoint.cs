namespace Domain.Entities
{
    public class CategoryTouristPoint
    {
        public int Id {get; set;}

        public int CategoryId {get; set;}
        public Category Category {get; set;}
        public int TouristPointId {get; set;}
        public TouristPoint TouristPoint {get; set;}

        //public  List<TouristPoint>  TouristPoints {get; set;}
        // public void UpdateInformation()
        // {

        // }
    }
}