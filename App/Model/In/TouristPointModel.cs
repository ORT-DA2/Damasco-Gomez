using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Entities;

namespace Model.In
{
    public class TouristPointModel
    {
         public string Name {get; set;}

         public string Image {get; set;}

        public string Description {get; set;}

        public int RegionId {get; set;}
        public virtual  IEnumerable<int> CategoriesTouristPoints {get; set;}

        public TouristPoint ToEntity()
        {
            return new TouristPoint()
            {
                Name= this.Name,
                Image = this.Image,
                Description = this.Description,
                RegionId = this.RegionId,
                CategoriesTouristPoints = this.CategoriesTouristPoints.Select(m => new CategoryTouristPoint()
                {
                    CategoryId = m
                }).ToList()
            };
        }

    }
}