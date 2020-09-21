namespace BusinessLogicInterface
{
    public interface IRegionLogic
    {
         void AddRegion(string name, string token);

         void DeleteRegion(int id, string token);

         void AddTouristPoint(int id, string touristPoint, string token);

         void GetTouristPoints();

         void GetTouristPointById(int id);

         void GetCategoryByName(string name);
    }
}