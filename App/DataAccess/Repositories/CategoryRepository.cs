using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<Category> categories;
        private readonly DbContext vidlyContext;
        public CategoryRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.categories = context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categories;
        }
    }
}