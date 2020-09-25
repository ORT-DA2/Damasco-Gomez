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
        private readonly VidlyContext managerContext;

        public Repository(VidlyContext context)
        {
            this.managerContext = context;
            this.dbSet = context.Set<T>();
        }

        public void AddInContext(T element)
        {
            this.dbSet.Add(element);
            this.managerContext.SaveChanges();
        }
        public void UpdateInContext(T element)
        {
            this.dbSet.Update(element);
            this.managerContext.SaveChanges();
        }

        public void Delete(T element)
        {
            this.dbSet.Remove(element);
            this.managerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = this.dbSet.Find(id);
            this.managerContext.Entry(entityToDelete).State = EntityState.Deleted;
            this.managerContext.SaveChanges();
        }

        public bool ExistInRepository(T element)
        {
            return this.dbSet.ToList().Contains(element);
        }

        public bool ExistInRepository(Predicate<T> element)
        {
            return this.dbSet.ToList().Exists(element);
        }

        public bool ExistInRepository(int id)
        {
            return this.dbSet.Find(id) != null;
        }

        public T FindInRepository(Predicate<T> element)
        {
            return this.dbSet.ToList().Find(element);
        }
        public T FindInRepository(int id)
        {
            return this.dbSet.Find(id);
        }
        public List<T> GetElementsInContext()
        {
            return this.dbSet.ToList();
        }
    }
}