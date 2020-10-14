using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface IPersonLogic
    {
        IEnumerable<Person> GetAll();
        Person GetBy(int id);
        Person Add(Person element);
        Person Update(int id,Person element);
        void Delete(int id);
        void Delete();
        bool Exist(Person element);
    }
}