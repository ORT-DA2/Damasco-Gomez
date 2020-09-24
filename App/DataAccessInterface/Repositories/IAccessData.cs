using System;
using System.Collections.Generic;

namespace DataAccessInterface.Repositories
{
    public interface IAccessData<T> where T : class
    {
        void Add(T element);
        bool Exist(T element);
        bool Exist(int id);
        T Find(int id);
        void Delete(T element);
        void Delete(int id);
        void Update(T element);
    }
}