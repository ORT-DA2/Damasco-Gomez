using Domain.Entities;

namespace Model.Out
{
    public class ImageBasicModel
    {
        public int Id {get ; set ; }
        public string Name {get; set;}
        public ImageBasicModel(Image image)
        {
            this.Id = image.Id;
            this.Name = image.Name;
        }
    }
}