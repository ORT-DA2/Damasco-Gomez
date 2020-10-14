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
            return new TouristPoint()
            {
                Name= this.Name,
                Image = this.Image,
                Description = this.Description,
                RegionId = this.RegionId,
                CategoriesTouristPoints = this.Categories.Select(m => new CategoryTouristPoint()
                {
                    CategoryId = m
                }).ToList()
            };
        }
    }
}