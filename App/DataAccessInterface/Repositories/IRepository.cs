using System;
using System.Collections.Generic;

namespace DataAccessInterface.Repositories
{
    public interface IRepository<T> where T : class
    {
        void AddInContext(T element);
        void UpdateInContext(T element);
        bool ExistInRepository(T element);
        bool ExistInRepository(Predicate<T> element);
        bool ExistInRepository(int id);
        void Delete(T element);
        void Delete(int id);
        T FindInRepository(Predicate<T> element);
        T FindInRepository(int id);
        List<T> GetElementsInContext();
    }
}