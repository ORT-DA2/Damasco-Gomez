using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Entities;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<TouristPointBasicInfoModel> TouristPoints {get; set;}

        public CategoryBasicInfoModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.TouristPoints = category.CategoryTouristPoints.Select(m=>new TouristPointBasicInfoModel(m.TouristPoint)).ToList();

        }

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is CategoryBasicInfoModel category)
            {
                result = this.Id == category.Id ;
            }
            return result;
        }
    }
}