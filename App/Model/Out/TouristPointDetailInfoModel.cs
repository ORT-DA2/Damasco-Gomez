using System.Linq;
using Domain;

namespace Model.Out
{
    public class TouristPointDetailInfoModel
    {
        public int Id {get; set;}
        public string Name {get; set;}

         public string Image {get; set;}

        public string Description {get; set;}

        public int RegionId {get; set;}
        //public virtual  List<CategoryTouristPoint> CategoriesTouristPoints {get; set;}
        //public virtual  List<CategoryTouristPointDetailInfoModel> CategoriesTouristPoints {get; set;} ?????

        public TouristPointDetailInfoModel(TouristPoint touristPoint)
        {
            this.Id = touristPoint.Id;
            this.Name = touristPoint.Name;
            this.Image = touristPoint.Image;
            this.Description = touristPoint.Description;
            this.RegionId = touristPoint.RegionId;
            //this.CategoriesTouristPoints = touristPoint.CategoriesTouristPoints.Select(m=>new TouristPointDetailInfoModel(m.TouristPoint)).ToList();

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