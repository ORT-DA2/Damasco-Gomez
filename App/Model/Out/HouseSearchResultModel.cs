using Domain;

namespace Model
{
    public class HouseSearchResultModel
    {
        public string CheckIn {get; set;}
        public string CheckOut{get; set;}
        public int CantPersons {get; set;}
        public int Id {get ; set ; }
        public double TotalPrice {get; set;}
        public int TouristPointId {get ; set; }
        public TouristPoint TouristPoint {get ; set; }
        public string Name {get ; set; }
        public int Starts {get ; set; }
        public string Address {get ; set; }
        public string Ilustrations {get ; set; }
        public string Description {get ; set;}
        public HouseSearchResultModel(House house, string checkIn, string checkOut,int cantA, int cantC,int cantB) 
        {
            this.Id= house.Id;
            this.TouristPoint = house.TouristPoint;
            this.TouristPointId = house.TouristPointId;
            this.Name= house.Name;
            this.Starts = house.Starts;
            this.Address= house.Address;
            this.Ilustrations= house.Ilustrations;
            this.Description= house.Description;
            this.TotalPrice= house.CalculateTotalPrice(cantA,cantC,cantB);
            this.CheckIn= checkIn;
            this.CheckOut = checkOut;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is HouseSearchResultModel house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
    }
}