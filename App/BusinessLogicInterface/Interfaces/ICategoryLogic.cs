using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {

        IEnumerable<Category> GetAll();
        Category GetBy(int id);
    }
}