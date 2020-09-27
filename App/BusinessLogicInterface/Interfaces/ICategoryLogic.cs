using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category GetBy(int id);
        void Add(Category element);
        void Update(Category element);
        void Delete(int id);
        void Delete();
        bool Exist(Category element);
    }
}