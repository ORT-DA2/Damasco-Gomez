using DataAccessInterface.Repositories;

namespace DataAccess.Repositories
{
    public abstract class AccessData<T> : IAccessData<T> where T : class
    {
        void IAccessData<T>.Add(T element)
        {
            throw new System.NotImplementedException();
        }

        void IAccessData<T>.Delete(T element)
        {
            throw new System.NotImplementedException();
        }

        void IAccessData<T>.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        bool IAccessData<T>.Exist(T element)
        {
            throw new System.NotImplementedException();
        }

        bool IAccessData<T>.Exist(int id)
        {
            throw new System.NotImplementedException();
        }

        T IAccessData<T>.Find(int id)
        {
            throw new System.NotImplementedException();
        }

        void IAccessData<T>.Update(T element)
        {
            throw new System.NotImplementedException();
        }
    }
}