using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class HouseSearch
    {
        public DateTime CheckIn {get;  set;}
        public DateTime CheckOut{get;  set;}
        public int TouristPointId {get ; set; }
        public int CantAdults {get;  set;}
        public int CantChildrens {get; set;}
        public int CantBabys {get; set;}
        public int CantSeniors {get; set;}
    }
}