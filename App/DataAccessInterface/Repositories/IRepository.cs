using System.Collections.Generic;

namespace DataAccessInterface.Repositories
{
    public interface IRepository<T> where T : class
    {
        T AddInContext(T element);
        void UpdateInContext(T element);
        bool ExistInRepository(T element);
        bool ExistInRepository(int id);
        void Delete(T element);
        void Delete(int id);
        T FindInRepository(int id);
        List<T> GetElementsInContext();
    }
}