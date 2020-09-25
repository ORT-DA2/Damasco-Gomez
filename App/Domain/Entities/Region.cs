using System;
using System.Collections.Generic;

namespace Domain
{
    public class Region
    {
        public int Id {get; set; }

        public string Name {get; set;}

        public List<TouristPoint> TouristPoints {get; set; }
        // public void UpdateInformation()
        // {

        // }
        public override bool Equals (object obj)
        {

            var result = false;

            if (obj is Region region)
            {

                result = this.Id == region.Id && this.Name.Equals(region.Name);
            }
            return result; 
        }


    }
}