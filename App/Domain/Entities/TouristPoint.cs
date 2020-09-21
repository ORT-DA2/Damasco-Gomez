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
        public Region Region {get; set;}
        public List<CategoryTouristPoint> CategoriesTouristPoints {get; set;}

        // public void UpdateInformation (string name, string image, string description)
        // {
        //     Name = name ;
        //     Description = description;
        //     Image = image;
        // }
    }
}