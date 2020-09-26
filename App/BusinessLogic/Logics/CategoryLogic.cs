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
        public void Delete(int id)
        {
            this.CategoryRepository.Delete(id);
        }

        public void Delete()
        {
            foreach(Category category in this.CategoryRepository.GetElements())
            {
                this.Delete(category.Id);
            }
        }
        public bool Exist(Category category)
        {
            return this.CategoryRepository.ExistElement(category);
        }
    }
}