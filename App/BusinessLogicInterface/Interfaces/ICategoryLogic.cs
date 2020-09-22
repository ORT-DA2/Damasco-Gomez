using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {

        IEnumerable<Category> GetAll();
        //  void AddCategory(string name, string token);

        //  void DeleteCategory(int id, string token);

        //  void GetTouristPointById(int id);

        //  void GetTouristPoints();

        //  void GetCategoryByName(string name);
    }
}