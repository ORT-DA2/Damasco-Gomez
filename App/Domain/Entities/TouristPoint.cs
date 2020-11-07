using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Domain
{
    public class TouristPoint
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int ImageTouristPointId {get; set;}
        public virtual ImageTouristPoint ImageTouristPoint {get; set;}
        public string Description {get; set;}
        public int RegionId {get; set;}
        public virtual Region Region {get; set;}
        public virtual  List<CategoryTouristPoint> CategoriesTouristPoints {get; set;}
        [ExcludeFromCodeCoverage]
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
            if(element.ImageTouristPoint != null) this.ImageTouristPoint = element.ImageTouristPoint;
            if(element.Description != null) this.Description = element.Description;
            if(element.RegionId>0) this.RegionId = element.RegionId;
        }
    }
}