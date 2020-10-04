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
        public static void Update(TouristPoint elementToUpdate, TouristPoint element)
        {
            if(element.Name != null) elementToUpdate.Name = element.Name;
            if(element.Image != null) elementToUpdate.Image = element.Image;
            if(element.Description != null) elementToUpdate.Description = element.Description;
            if(element.RegionId>0) elementToUpdate.RegionId = element.RegionId;
        }
    }
}