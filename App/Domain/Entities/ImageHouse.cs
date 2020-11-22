using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class ImageHouse
    {
        public int Id {get ; set ;}
        public string Name {get; set;}
        public string Extention {get; set;}
        public int HouseId {get; set;}
        [ExcludeFromCodeCoverage]
        public ImageHouse(string name, int houseId)
        {
            this.Name = name;
            this.HouseId = houseId;
            this.Extention = GetExtention(name);
        }
        public void Update(ImageHouse element)
        {
            if(element.Name != "") 
            { 
                this.Name = element.Name;
                this.Extention = GetExtention(element.Name);
            }
        }
        private string GetExtention(string name)
        {
            if(name.Contains("."))
            {
                return name.Split('.')[1];
            }
            else 
            {
                throw new ArgumentException("Name doesn't have extention");
            }
        }
    }
}