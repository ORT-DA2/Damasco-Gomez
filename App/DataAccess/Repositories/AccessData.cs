using System;
using DataAccess.Context;
using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public abstract class AccessData<T> : IAccessData<T> where T : class
    {
        private IRepository<T> repository;
        protected abstract void Validate(T element);
        public void Add(T element)
        {
            Validate(element);
            if (ExistElement(element))
            {
                throw new ArgumentException();
            }
            repository.AddInContext(element);
        }

        public bool ExistElement(T element)
        {
            return repository.ExistInRepository(element);
        }
        public bool ExistElement(int id)
        {
            return repository.ExistInRepository(id);
        }
        public bool ExistElement(Predicate<T> element)
        {
            return repository.ExistInRepository(element);
        }

        public void Delete(T element)
        {
            if (!ExistElement(element))
            {
                throw new ArgumentException();
            }
            repository.Delete(element);
        }

        public void Delete(int id)
        {
            if (!ExistElement(id))
            {
                throw new ArgumentException();
            }
            repository.Delete(id);
        }

        // T IAccessData<T>.Find(int id)
        // {
        //     throw new System.NotImplementedException();
        // }

        // void IAccessData<T>.Update(T element)
        // {
        //     throw new System.NotImplementedException();
        // }

    }
}