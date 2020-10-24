using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Domain;

namespace Model.Out
{
    [ExcludeFromCodeCoverage]
    public class TouristPointDetailInfoModel
    {
        public int Id {get; private set;}
        public string Name {get; private set;}
        public ImageTouristPointBasicModel Image {get; private set;}
        public string Description {get; private set;}
        public int RegionId {get; private set;}
        public  List<CategoryBasicInfoModel> Categories {get; private set;}
        public TouristPointDetailInfoModel(TouristPoint touristPoint)
        {
            if (touristPoint!= null)
            {
                this.Id = touristPoint.Id;
                this.Name = touristPoint.Name;
                // this.Image = new ImageBasicModel(touristPoint.Image);
                this.Description = touristPoint.Description;
                this.RegionId = touristPoint.RegionId;
                this.Categories = touristPoint.CategoriesTouristPoints.
                    Select(m => new CategoryBasicInfoModel(m.Category)).ToList();
            }
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is TouristPointDetailInfoModel touristPoint)
            {
                result = this.Id == touristPoint.Id ;
            }
            return result;
        }
    }
}