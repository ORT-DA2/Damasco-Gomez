using System;

namespace Domain.Entities
{
    public class HouseSearch
    {
        public DateTime CheckIn {get;  set;}
        public DateTime CheckOut{get;  set;}
        public int TouristPointId {get ; set; }
        public int CantAdults {get;  set;}
        public int CantChildrens {get; set;}
        public int CantBabys {get; set;}
    }
}