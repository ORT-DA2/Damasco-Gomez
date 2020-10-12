using System;
using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model
{
    [ExcludeFromCodeCoverage]
    public class HouseModel
    {
        public bool Avaible {get ; set; }
        public int PricePerNight {get; set;}
        public int TouristPointId {get ; set; }
        public string Name {get ; set; }
        public int Starts {get ; set; }
        public string Address {get ; set; }
        public string Ilustrations {get ; set; }
        public string Description {get ; set;}
        public int Phone {get; set; }
        public string Contact {get; set;}
        public House ToEntity()
        {
            House newHouse = new House()
            {
                Avaible = this.Avaible,
                PricePerNight = this.PricePerNight,
                TouristPointId = this.TouristPointId,
                Name = this.Name,
                Starts = this.Starts,
                Address = this.Address,
                Ilustrations = this.Ilustrations,
                Description = this.Description,
                Phone = this.Phone,
                Contact = this.Contact
            };
            if (newHouse.IsEmpty()) throw new ArgumentException("The values are all empty");
            return newHouse;
        }
    }
}