using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {

        IEnumerable<Category> GetAll();
        Category GetBy(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        void Delete();
    }
}