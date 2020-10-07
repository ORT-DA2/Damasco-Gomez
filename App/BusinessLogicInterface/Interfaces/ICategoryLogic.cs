using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category GetBy(int id);
        Category Add(Category element);
        Category Update(int id,Category element);
        void Delete(int id);
        void Delete();
        bool Exist(Category element);
    }
}