using System.Collections.Generic;

namespace DataAccessInterface.Repositories
{
    public interface IAccessData<T> where T : class
    {
        T Add(T element);
        bool ExistElement(T element);
        bool ExistElement(int id);
        void Delete(T element);
        void Delete(int id);
        T Find(int id);
        void Update(int id, T element);
        List<T> GetElements();
    }
}