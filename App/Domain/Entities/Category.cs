using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Domain
{
    public class Category
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public virtual List<CategoryTouristPoint>  CategoryTouristPoints {get; set;}
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is Category category)
            {
                result = this.Id == category.Id;
            }
            return result;
        }
        public static void Update(Category elementToUpdate, Category element)
        {
            if(element.Name != null) elementToUpdate.Name = element.Name;
        }
    }
}