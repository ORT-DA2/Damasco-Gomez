using Domain;

namespace Model.Out
{
    public class TouristPointBasicInfoModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Image {get; set;}
        public string Description {get; set;}
        public int RegionId {get; set;}
        public TouristPointBasicInfoModel (TouristPoint touristPoint)
        {
            this.Id = touristPoint.Id;
            this.Name = touristPoint.Name;
            this.Image = touristPoint.Image;
            this.Description = touristPoint.Description;
            this.RegionId = touristPoint.RegionId;
        }
    }
}