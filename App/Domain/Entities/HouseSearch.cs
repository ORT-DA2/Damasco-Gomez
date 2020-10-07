namespace Domain.Entities
{
    public class HouseSearch
    {
        public string CheckIn {get;  set;}
        public string CheckOut{get;  set;}
        public int TouristPointId {get ; set; }
         public int CantAdults {get;  set;}
         public int CantChildrens {get; set;}
         public int CantBabys {get; set;}
    }
}