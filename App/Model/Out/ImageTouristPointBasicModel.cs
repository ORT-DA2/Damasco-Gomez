using Domain.Entities;

namespace Model.Out
{
    public class ImageTouristPointBasicModel
    {
        public int Id {get ; set ; }
        public string Name {get; set;}
        public ImageTouristPointBasicModel(ImageTouristPoint image)
        {
            this.Id = image.Id;
            this.Name = image.Name;
        }
    }
}