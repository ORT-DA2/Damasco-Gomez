using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class CategoryLogic : Logic<Category> , ICategoryLogic
    {
        private readonly ICategoryRepository CategoryRepository;
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        public override void Delete()
        {
            foreach(Category category in this.CategoryRepository.GetElements())
            {
                this.Delete(category.Id);
            }
        }
    }
}