using System;
using DataAccessInterface.Repositories;
using Domain;

namespace DataAccess.Repositories
{
    public class CategoryRepository : AccessData<Category> , ICategoryRepository
    {
        public CategoryRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Categories;
        }

        protected override void Update(Category elementToUpdate, Category element)
        {
            Category.Update(elementToUpdate,element);
        }

        protected override void Validate(Category element)
        {
            if (element == null)
            {
                throw new ArgumentException("Category is empty");
            }
            if (element.Name.Equals(""))
            {
                throw new ArgumentException("Name of category should not be null");
            }
        }
    }
}