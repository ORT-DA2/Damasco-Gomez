using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model.Out
{
    [ExcludeFromCodeCoverage]
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
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is TouristPointBasicInfoModel touristPoint)
            {
                result = this.Id == touristPoint.Id ;
            }
            return result;
        }
    }
}
