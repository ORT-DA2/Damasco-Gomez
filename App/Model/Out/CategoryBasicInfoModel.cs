using System.Collections.Generic;
using Domain;
using Domain.Entities;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<CategoryTouristPoint> CategoryTouristPoints {get; set;}

        public CategoryBasicInfoModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.CategoryTouristPoints = category.CategoryTouristPoints;
        }

        public CategoryBasicInfoModel()
        {
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