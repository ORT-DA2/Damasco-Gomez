using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public class Category
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public  List<CategoryTouristPoint>  CategoryTouristPoints {get; set;}
        // public void UpdateInformation()
        // {

        // }
    }
}