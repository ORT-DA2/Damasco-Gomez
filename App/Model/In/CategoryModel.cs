using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Entities;

namespace Model.In
{
    public class CategoryModel
    {
        public string Name {get; set;}
        public  IEnumerable<int> TouristPoints {get; set;}
        public Category ToEntity()
        {
            return new Category()
            {
                Name= this.Name,
                CategoryTouristPoints = this.TouristPoints.Select(m => new CategoryTouristPoint()
                {
                    TouristPointId = m
                }).ToList()
            };
        }
    }
}