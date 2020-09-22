using System.Collections.Generic;
using Domain;

namespace DataAccessInterface.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}