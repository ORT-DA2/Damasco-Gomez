using System;
namespace Domain
{
    public class Region
    {
        public int Id {get; set; }

        public string Name {get; set;}

        public List<TouristPoint> TouristPoints {get; set; }


    }
}