using Domain;
using Domain.Entities;

namespace Model.In
{
    public class HouseSearchModel
    {
        public string CheckIn {get; set;}
        public string CheckOut{get; set;}
        public int TouristPointId {get ; set; }
        public int CantAdults {get; set;}
        public int CantChildrens {get; set;}
        public int CantBabys {get; set;}
        public HouseSearch ToEntity()
        {
            return new HouseSearch()
            {
                CheckIn = this.CheckIn,
                CheckOut = this.CheckOut,
                TouristPointId = this.TouristPointId,
                CantAdults = this.CantAdults,
                CantChildrens = this.CantChildrens,
                CantBabys = this.CantBabys
            };
        }

    }
}