using System;
using DataAccess.Context;
using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public abstract class AccessData<T> : IAccessData<T> where T : class
    {
        protected IRepository<T> repository;
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

        public T Find(int id)
        {
            var elementFind = repository.FindInRepository(id);
            if (elementFind == null)
            {
                return null;
                //throw new ArgumentException();
            }
            return elementFind;
        }

        public T Find(Predicate<T> element)
        {
            var elementFind = repository.FindInRepository(element);
            if (elementFind == null)
            {
                return null;
                //throw new ArgumentException();
            }
            return elementFind;
        }

        public void Update(T element)
        {
            Validate(element);
            if (!ExistElement(element))
            {
                //throw new ArgumentException();
            }
            repository.UpdateInContext(element);
        }

        public List<T> GetElements()
        {
            return repository.GetElementsInContext();
        }

    }
}