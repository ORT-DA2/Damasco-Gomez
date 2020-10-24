using Domain;
using Model.Out;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Model
{
    [ExcludeFromCodeCoverage]
    public class HouseDetailModel
    {
        public int Id {get ; set ; }
        public bool Avaible {get ; set; }
        public int PricePerNight {get; set;}
        public int TouristPointId {get ; set; }
        public TouristPointBasicInfoModel TouristPoint {get ; set; }
        public string Name {get ; set; }
        public int Starts {get ; set; }
        public string Address {get ; set; }
        public List<ImageBasicModel> Images {get ; set; }
        public string Description {get ; set;}
        public int Phone {get; set; }
        public string Contact {get; set;}

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is HouseDetailModel house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
        public HouseDetailModel(House house)
        {
            this.Id = house.Id;
            this.Avaible = house.Avaible;
            this.Address = house.Address;
            this.PricePerNight = house.PricePerNight;
            this.Phone = house.Phone;
            this.TouristPointId = house.TouristPointId;
            this.TouristPoint = new TouristPointBasicInfoModel(house.TouristPoint);
            this.Name = house.Name;
            this.Starts = house.Starts;
            // this.Images = house.Images.Select(m => new ImageBasicModel(m)).ToList();
            this.Description = house.Description;
            this.Contact = house.Contact;
        }
    }
}