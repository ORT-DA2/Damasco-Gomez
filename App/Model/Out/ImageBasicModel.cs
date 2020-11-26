using Domain.Entities;

namespace Model.Out
{
    public class ImageHouseBasicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageHouseBasicModel(ImageHouse image)
        {
            if (image != null)
            {
                this.Id = image.Id;
                this.Name = image.Name;
            }
        }
    }
}