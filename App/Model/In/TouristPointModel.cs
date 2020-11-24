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
        public virtual  IEnumerable<int> Categories {get; set;}
        public TouristPoint ToEntity()
        {
            TouristPoint touristPoint = new TouristPoint()
            {
                Name= this.Name,
                Description = this.Description,
                RegionId = this.RegionId,
            };
            if (this.Categories!=null)
            {
                touristPoint.CategoriesTouristPoints = this.Categories.Select(m => new CategoryTouristPoint()
                {
                    CategoryId = m
                }).ToList();
            };
            if (this.Image != null) 
            {
                touristPoint.ImageTouristPoint = new ImageTouristPoint(this.Image);
            }
            if (this.RegionId > 0)
            {
                touristPoint.Region = new Region(){Id = this.RegionId};
            }
            return touristPoint;
        }
    }
}