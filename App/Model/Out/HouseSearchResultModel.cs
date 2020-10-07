using Domain;
using Domain.Entities;

namespace Model
{
    public class HouseSearchResultModel
    {
        public int CantPersons {get; private set;}
        public int HouseId {get ; private set ; }
        public double TotalPrice {get; private set;}
        public string Name {get ; private set; }
        public int Starts {get ; private set; }
        public string Address {get ; private set; }
        public string Ilustrations {get ; private set; }
        public string Description {get ; private set;}
        public HouseSearchResultModel(House house, HouseSearch houseSearch)
        {
            this.HouseId= house.Id;
            this.CantPersons = houseSearch.CantAdults + houseSearch.CantBabys + houseSearch.CantChildrens;
            this.Name= house.Name;
            this.Starts = house.Starts;
            this.Address= house.Address;
            this.Ilustrations= house.Ilustrations;
            this.Description= house.Description;
            this.TotalPrice= house.CalculateTotalPrice(houseSearch);
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is HouseSearchResultModel house)
            {
                result = this.HouseId == house.HouseId ;
            }
            return result;
        }
    }
}