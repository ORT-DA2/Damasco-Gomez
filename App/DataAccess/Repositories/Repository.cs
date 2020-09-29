using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> dbSet;
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public T AddInContext(T element)
        {
            this.dbSet.Add(element);
            this.context.SaveChanges();
            return element;
        }
        public void UpdateInContext(T element)
        {
            this.dbSet.Update(element);
            this.context.SaveChanges();
             
        }

        public void Delete(T element)
        {
            this.dbSet.Remove(element);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = this.dbSet.Find(id);
            this.dbSet.Remove(entityToDelete);
            this.context.SaveChanges();
        }

        public bool ExistInRepository(T element)
        {
            var find = this.dbSet.ToList().Contains(element);
            return find;
        }

        public bool ExistInRepository(Predicate<T> element)
        {
            var find = this.dbSet.ToList().Exists(element);
            return find;
        }

        public bool ExistInRepository(int id)
        {
            var find = this.dbSet.Find(id);
            return find != null;
        }

        public T FindInRepository(Predicate<T> element)
        {
            var find = this.dbSet.ToList().Find(element);
            return find;
        }
        public T FindInRepository(int id)
        {
            var find = this.dbSet.Find(id);
            return find;
        }
        public List<T> GetElementsInContext()
        {
            return this.dbSet.ToList();
        }
    }
}