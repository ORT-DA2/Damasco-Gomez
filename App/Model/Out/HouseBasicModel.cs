using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain;
using Domain.Entities;
using Model.Out;

namespace Model
{
    [ExcludeFromCodeCoverage]
    public class HouseBasicModel
    {
        public int Id {get ; set ; }
        public bool Avaible {get ; set; }
        public int PricePerNight {get; set;}
        public int TouristPointId {get ; set; }
        public string Name {get ; set; }
        public int Starts {get ; set; }
        public string Address {get ; set; }
        public List<ImageHouseBasicModel> Images {get ; set; }
        public string Description {get ; set;}
        public int Phone {get; set; }
        public string Contact {get; set;}
        public double TotalPrice {get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is HouseBasicModel house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
        public HouseBasicModel(House house, HouseSearch houseSearch = null)
        {
            this.Id = house.Id;
            this.Avaible = house.Avaible;
            this.Address = house.Address;
            this.PricePerNight = house.PricePerNight;
            this.Phone = house.Phone;
            this.TouristPointId = house.TouristPointId;
            this.Name = house.Name;
            this.Starts = house.Starts;
            // this.Images = house.Images.Select(m => new ImageBasicModel(m)).ToList();
            this.Description = house.Description;
            this.Contact = house.Contact;
            if(houseSearch!=null) this.TotalPrice = house.CalculateTotalPrice(houseSearch);
        }
    }
}