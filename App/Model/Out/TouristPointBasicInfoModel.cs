using Domain;

namespace Model.Out
{
    public class TouristPointBasicInfoModel
    {
          public int Id {get; private set;}

         public string Name {get; private set;}

         public string Image {get; private set;}

        public string Description {get; private set;}

        public int RegionId {get; private set;}

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
