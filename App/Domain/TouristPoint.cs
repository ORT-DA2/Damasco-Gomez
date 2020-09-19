using System;

namespace Domain
{
    public class TouristPoint
    {
         public int Id {get; set;}

         public string Name {get; set;}

         public Image Image {get; set; }

        public string Description {get; set;}

        public void UpdateImage ( Image image)
        {
            Image = image;

        }
        public void UpdateDescription (string description)
        {

            Description = description;
        }
        public void UdpateName (string name)
        {
            Name = name ;
        }
    }
}