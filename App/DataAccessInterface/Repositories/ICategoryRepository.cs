using System.Collections.Generic;
using Domain;

namespace DataAccessInterface.Repositories
{
    public interface ICategoryRepository : IAccessData<Category>
    {
        IEnumerable<Category> GetAll();
    }
}