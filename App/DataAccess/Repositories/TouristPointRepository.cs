using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TouristPointRepository
    {
        protected DbContext Context {get; set;}
        public TouristPointRepository(DbContext context)
        {
            Context = context;
        }
        public TouristPoint Get(int id)
        {
            return Context.Set<TouristPoint>().First(x=>x.Id==id);
        }
        public IEnumerable<TouristPoint> GetAll()
        {
            return Context.Set<TouristPoint>().ToList();
        }
        public void Add(TouristPoint entity)
        {
            Context.Set<TouristPoint>().Add(entity);
        }
        public void Remove(TouristPoint entity)
        {
            Context.Set<TouristPoint>().Remove(entity);
        }
        public void Update(TouristPoint entity)
        {
            Context.Entry(entity).State=EntityState.Modified;
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}