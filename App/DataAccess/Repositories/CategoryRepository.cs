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

        protected override void Validate(Category element)
        {
            if (element.Name.Equals(""))
            {
                throw new ArgumentException("Name of category should not be null");
            }
        }
    }
}