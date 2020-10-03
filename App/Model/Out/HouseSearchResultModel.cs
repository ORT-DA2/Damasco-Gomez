using Domain;

namespace Model
{
    public class HouseSearchResultModel
    {
        public string CheckIn {get; set;}

        public string CheckOut{get; set;}

        public int CantPersons {get; set;}

         public int Id {get ; set ; }

        public int TotalPrice {get; set;}

        public int TouristPointId {get ; set; }
        public TouristPoint TouristPoint {get ; set; }

        public string Name {get ; set; }

        public int Starts {get ; set; }

        public string Address {get ; set; }

        public string Ilustrations {get ; set; }

        public string Description {get ; set;}

        public HouseSearchResultModel(House house) 
        {
            this.Id= house.Id;
            this.TouristPoint = house.TouristPoint;
            this.TouristPointId = house.TouristPointId;
            this.Name= house.Name;
            this.Starts = house.Starts;
            this.Address= house.Address;
            this.Ilustrations= house.Ilustrations;
            this.Description= house.Description;
        }

    }
}