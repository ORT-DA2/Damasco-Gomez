using System;
using System.Collections.Generic;

namespace DataAccessInterface.Repositories
{
    public interface IAccessData<T> where T : class
    {
        void Add(T element);
        bool ExistElement(T element);
        bool ExistElement(int id);
        bool ExistElement(Predicate<T> element);
        void Delete(T element);
        void Delete(int id);
        T Find(int id);
        T Find(Predicate<T> element);
        void Update(T element);
        List<T> GetElements();
    }
}