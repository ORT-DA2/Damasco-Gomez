using System;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class ImageTouristPoint
    {
        public int Id {get ; set ;}
        public string Name {get; set;}
        public string Extention {get; set;}
        [ExcludeFromCodeCoverage]
        public ImageTouristPoint(string name)
        {
            this.Name = name;
            this.Extention = GetExtention(name);
        }
        public void Update(ImageTouristPoint image)
        {
            if (image.Name != null) 
            {
                this.Name = image.Name;
                this.Extention = GetExtention(image.Name);
            }
        }
        private string GetExtention(string name)
        {
            if(name.Contains("."))
            {
                return name.Split('.')[1];
            }
            else 
            {
                throw new ArgumentException("Name doesn't have extention");
            }
        }
    }
}