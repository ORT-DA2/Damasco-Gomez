using BusinessLogicInterface;
using DataAccessInterface.Repositories;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        // public void AddCategory(string name, string token)
        // {
            
        // }
        // public void DeleteCategory(int id, string token)
        // {
            
        // }
        // public void GetTouristPointById(int id)
        // {
            
        // }
        // public void GetTouristPoints()
        // {
            
        // }
        // public void GetCategoryByName(string name)
        // {
            
        // }
    }
}