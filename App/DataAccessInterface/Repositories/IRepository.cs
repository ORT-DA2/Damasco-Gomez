using System;

namespace DataAccessInterface.Repositories
{
    public interface IRepository<T> where T : class
    {
        void AddInContext(T element);
        bool ExistInRepository(T element);
        bool ExistInRepository(Predicate<T> element);
        bool ExistInRepository(int id);
        void Delete(T element);
        void Delete(int id);
        // T Find(int id);
        // void Update(T element);
    }
}