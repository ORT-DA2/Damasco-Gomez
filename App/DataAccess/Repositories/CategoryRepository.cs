using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

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
            throw new System.NotImplementedException();
        }
    }
}