using System;
using System.Diagnostics.CodeAnalysis;
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
        [ExcludeFromCodeCoverage]
        protected override void Update(Category elementToUpdate, Category element)
        {
            elementToUpdate.Update(element);
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