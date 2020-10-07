using Domain;
using Domain.Entities;

namespace Model.In
{
    public class HouseSearchModel
    {
        public string CheckIn {get; private set;}
        public string CheckOut{get; private set;}
        public int TouristPointId {get ; private set; }
         public int CantAdults {get; private set;}
         public int CantChildrens {get; private set;}
         public int CantBabys {get; private set;}

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