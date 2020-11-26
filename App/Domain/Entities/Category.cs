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
        public void Update(Category element)
        {
            if(element.Name != "") this.Name = element.Name;
        }
        public bool IsEmpty()
        {
            bool nameNull = Name == null;
            return nameNull;
        }
    }
}