using Domain;

namespace Model
{
    public class HouseSearchResultModel
    {
        public string CheckIn {get; private set;}
        public string CheckOut{get; private set;}
        public int CantPersons {get; private set;}
        public int Id {get ; private set ; }
        public double TotalPrice {get; private set;}
        public int TouristPointId {get ;  private set; }
        public TouristPoint TouristPoint {get ; private set; }
        public string Name {get ; private set; }
        public int Starts {get ; private set; }
        public string Address {get ; private set; }
        public string Ilustrations {get ; private set; }
        public string Description {get ; private set;}
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