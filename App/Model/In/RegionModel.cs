using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain;

namespace Model.In
{
    public class RegionModel
    {
        [ExcludeFromCodeCoverageAttribute]
        public string Name {get; set;}
        //public List<int> TouristPoints {get; set;}
        public Region ToEntity()
        {
            return new Region()
            {
                Name= this.Name,
                // TouristPoints = this.TouristPoints.Select(m => new TouristPoint()
                // {
                //     Id = m
                // }).ToList()
            };
        }
    }
}