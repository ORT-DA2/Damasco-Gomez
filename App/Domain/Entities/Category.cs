using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public class Category
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public  List<CategoryTouristPoint>  CategoryTouristPoints {get; set;}
        
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
            if(!element.Name.Equals("")) elementToUpdate.Name = element.Name;
        }
    }
}