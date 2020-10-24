using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class ImageHouse
    {
        public int Id {get ; set ;}
        public string Name {get; set;}
        public string Extention {get; set;}
        [ExcludeFromCodeCoverage]
        public ImageHouse()
        {
        }
        public void Update(ImageHouse element)
        {
            if(element.Name != null) this.Name = element.Name;
        }
    }
}