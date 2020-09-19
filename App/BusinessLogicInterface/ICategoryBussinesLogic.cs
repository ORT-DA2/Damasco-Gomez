namespace BusinessLogicInterface
{
    public interface ICategoryBussinesLogic
    {
         void AddCategory(string name, string token);

         void DeleteCategory(int id, string token);

         void GetTouristPointById(int id);

         void GetTouristPoints();

         void GetCategoryByName(string name);
    }
}