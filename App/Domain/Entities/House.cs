using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Domain.Entities;

namespace Domain
{
    public class House
    {
        public int Id {get ; set ; }
        public bool Avaible {get ; set; }
        public int PricePerNight {get; set;}
        public int TouristPointId {get ; set; }
        public virtual TouristPoint TouristPoint {get ; set; }
        public string Name {get ; set; }
        public int Starts {get ; set; }
        public string Address {get ; set; }
        public string Ilustrations {get ; set; }
        public string Description {get ; set;}
        public int Phone {get; set; }
        public string Contact {get; set;}
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is House house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
        public double CalculateTotalPrice(HouseSearch houseSearch)
        {
            double TotalPrice = 0;
            if (houseSearch != null)
            {
                int priceNight = this.PricePerNight;
                int nights = (houseSearch.CheckOut - houseSearch.CheckIn).Days;
                double  PriceAdults = houseSearch.CantAdults * priceNight * nights;
                const double percentChildrens = 0.5;
                const double percentBabys = 0.5;
                double  PriceChildrens = houseSearch.CantChildrens* percentChildrens * priceNight * nights;
                double  PriceBabys = houseSearch.CantBabys * percentBabys * priceNight * nights;
                TotalPrice = PriceAdults + PriceChildrens + PriceBabys;
            }
            return TotalPrice ;
        }

        public void Update(House element)
        {
            //if(element.Avaible)
               this.Avaible = element.Avaible;
            if(element.PricePerNight>0) this.PricePerNight = element.PricePerNight;
            if(element.TouristPointId>0) this.TouristPointId = element.TouristPointId;
            if(element.Name != null) this.Name = element.Name;
            if(element.Starts>0) this.Starts = element.Starts;
            if(element.Address != null) this.Address = element.Address;
            if(element.Description != null) this.Description = element.Description;
            if(element.Ilustrations != null) this.Ilustrations = element.Ilustrations;
            if(element.Phone>0) this.Phone = element.Phone;
            if(element.Contact != null) this.Contact = element.Contact;
        }

        public bool IsAvailable()
        {
            return this.Avaible;
        }

    }
}