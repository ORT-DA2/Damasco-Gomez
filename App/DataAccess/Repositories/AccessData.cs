using System;
using DataAccessInterface.Repositories;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public abstract class AccessData<T> : IAccessData<T> where T : class
    {
        protected IRepository<T> repository;
        protected abstract void Validate(T element);
        protected abstract void Update(T elementToUpdate, T element);
        public T Add(T element)
        {
            Validate(element);
            if (ExistElement(element))
            {
                throw new ArgumentException();
            }
            return repository.AddInContext(element);
        }

        public bool ExistElement(T element)
        {
            return repository.ExistInRepository(element);
        }
        public bool ExistElement(int id)
        {
            return repository.ExistInRepository(id);
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
                throw new ArgumentException("No element with that id");
            }
            return elementFind;
        }

        public void Update(int id , T element)
        {
            T findElement = repository.FindInRepository(id);
            if (findElement == null)
            {
                throw new ArgumentException("No element with that id");
            }
            Update(findElement,element);
        }

        public List<T> GetElements()
        {
            return repository.GetElementsInContext();
        }

    }
}