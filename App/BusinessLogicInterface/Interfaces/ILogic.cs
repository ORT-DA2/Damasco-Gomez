using System.Collections.Generic;

namespace BusinessLogicInterface.Interfaces
{
    public interface ILogic<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetBy(int id);
        void Add(T element);
        void Update(T element);
        void Delete(int id);
        void Delete();
        bool Exist(T element);
    }
}