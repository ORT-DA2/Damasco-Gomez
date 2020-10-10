using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BusinessLogicInterface.Interfaces;
using DataAccessInterface.Repositories;

namespace BusinessLogic.Logics
{
    [ExcludeFromCodeCoverage]
    public abstract class Logic<T> : ILogic<T> where T : class
    {
        protected IAccessData<T> myAccessData;
        public abstract void Delete();
        public IEnumerable<T> GetAll()
        {
            return this.myAccessData.GetElements();
        }
        public  T GetBy(int id)
        {
            return this.myAccessData.Find(id);
        }

        public void Add(T T)
        {
            this.myAccessData.Add(T);
        }
        public void Update(int id, T T)
        {
            this.myAccessData.Update(id,T);
        }
        public void Delete(int id)
        {
            this.myAccessData.Delete(id);
        }
        public bool Exist(T T)
        {
            return this.myAccessData.ExistElement(T);
        }
    }
}