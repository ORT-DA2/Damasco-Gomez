using System;
using System.Collections.Generic;
using System.Drawing;

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

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is House house)
            {
                result = this.Id == house.Id ;
            }
            return result;
        }
        public double CalculateTotalPrice(int cantAdults,int  cantChildrens, int cantBabys)
        {
            int priceNight = this.PricePerNight;
            double  PriceAdults = cantAdults* priceNight;
            const double percentChildrens = 0.5;
            const double percentBabys = 0.5;
            double  PriceChildrens = cantChildrens* percentChildrens * priceNight;
            double  PriceBabys = cantBabys* percentBabys * priceNight;
            double TotalPrice= PriceAdults + PriceChildrens + PriceBabys;
            return TotalPrice ;
        }

        public static void Update(House elementToUpdate, House element)
        {
            //if(element.Avaible) 
                elementToUpdate.Avaible = element.Avaible;
            if(element.PricePerNight>0) elementToUpdate.PricePerNight = element.PricePerNight;
            if(element.TouristPointId>0) elementToUpdate.TouristPointId = element.TouristPointId;
            if(element.Name != null) elementToUpdate.Name = element.Name;
            if(element.Starts>0) elementToUpdate.Starts = element.Starts;
            if(element.Address != null) elementToUpdate.Address = element.Address;
            if(element.Description != null) elementToUpdate.Description = element.Description;
            if(element.Ilustrations != null) elementToUpdate.Ilustrations = element.Ilustrations;
            if(element.Phone>0) elementToUpdate.Phone = element.Phone;
            if(element.Contact != null) elementToUpdate.Contact = element.Contact;
        }

        public static bool IsAvailable(House house)
        {
            return house.Avaible;
        }

    }
}