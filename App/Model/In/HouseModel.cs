using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain;
using Domain.Entities;

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
        public List<string> Images {get ; set; }
        public string Description {get ; set;}
        public int Phone {get; set; }
        public string Contact {get; set;}
        public House ToEntity(bool post = true)
        {
            House newHouse = new House()
            {
                Avaible = this.Avaible,
                PricePerNight = this.PricePerNight,
                TouristPointId = this.TouristPointId,
                Name = this.Name,
                Starts = this.Starts,
                Address = this.Address,
                Description = this.Description,
                Phone = this.Phone,
                Contact = this.Contact
            };
            if (post && newHouse.IsEmpty()) throw new ArgumentException("The values are all empty");
            if (this.Images.Count > 0)
            {
                newHouse.ImagesHouse = this.Images.Select
                (
                    m => new ImageHouse(m, newHouse.Id)
                ).ToList();
            }
            return newHouse;
        }
    }
}