using System;
using System.Collections.Generic;

namespace Domain
{
    public class Region
    {
        public Guid Id {get; set; }

        public string Name {get; set;}

        public List<TouristPoint> TouristPoints {get; set; }


    }
}