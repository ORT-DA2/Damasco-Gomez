using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public class TouristPoint
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Image {get; set;}
        public string Description {get; set;}
        public int RegionId {get; set;}
        public virtual Region Region {get; set;}
        public virtual  List<CategoryTouristPoint> CategoriesTouristPoints {get; set;}

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is TouristPoint touristPoint)
            {
                result = this.Id == touristPoint.Id ;
            }
            return result;
        }
        public void Update(TouristPoint element)
        {
            if(element.Name != null) this.Name = element.Name;
            if(element.Image != null) this.Image = element.Image;
            if(element.Description != null) this.Description = element.Description;
            if(element.RegionId>0) this.RegionId = element.RegionId;
        }
    }
}