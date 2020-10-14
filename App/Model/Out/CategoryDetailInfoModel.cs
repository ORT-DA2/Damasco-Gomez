using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain;
using Domain.Entities;

namespace Model.Out
{
    [ExcludeFromCodeCoverage]
    public class CategoryDetailInfoModel
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public List<TouristPointBasicInfoModel> TouristPoints {get; private set;}

        public CategoryDetailInfoModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.TouristPoints = category.CategoryTouristPoints.Select(m=>new TouristPointBasicInfoModel(m.TouristPoint)).ToList();
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
