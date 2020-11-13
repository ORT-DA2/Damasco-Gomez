using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class ImageTouristPoint
    {
        public int Id {get ; set ;}
        public string Name {get; set;}
        public string Extention {get; set;}
        [ExcludeFromCodeCoverage]
        public ImageTouristPoint()
        {
        }
        public void Update(ImageTouristPoint image)
        {
            if (image.Name !=null) this.Name = image.Name;
        }
    }
}