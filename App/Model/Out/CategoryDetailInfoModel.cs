using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Entities;

namespace Model.Out
{
    public class CategoryDetailInfoModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<TouristPointDetailInfoModel> TouristPoints {get; set;}

        public CategoryDetailInfoModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.TouristPoints = category.CategoryTouristPoints.Select(m=>new TouristPointDetailInfoModel(m.TouristPoint)).ToList();

        }

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is CategoryDetailInfoModel category)
            {
                result = this.Id == category.Id ;
            }
            return result;
        }
    }
}