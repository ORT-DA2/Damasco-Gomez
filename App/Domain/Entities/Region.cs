using System;
using System.Collections.Generic;

namespace Domain
{
    public class Region
    {
        public int Id {get; set; }

        public string Name {get; set;}

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Region region)
            {
                result = this.Id == region.Id ;
            }
            return result;
        }
        public static void Update(Region elementToUpdate, Region element)
        {
            if(element.Name != null) elementToUpdate.Name = element.Name;
        }
    }
}