using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository CategoryRepository;
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return this.CategoryRepository.GetElements();
        }
        public Category GetBy(int id)
        {
            return this.CategoryRepository.Find(id);
        }

        public void Add(Category category)
        {
            this.CategoryRepository.Add(category);
        }
        public void Update(Category category)
        {
            this.CategoryRepository.Update(category);
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