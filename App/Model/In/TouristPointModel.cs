using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain;
using Domain.Entities;

namespace Model.In
{
    [ExcludeFromCodeCoverage]
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
                ImageTouristPoint = new ImageTouristPoint()
                {
                    Name = this.Image
                },
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
            return touristPoint;
        }
    }
}