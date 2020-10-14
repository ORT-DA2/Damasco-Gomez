using Domain;

namespace DataAccessInterface.Repositories
{
    public interface IPersonRepository : IAccessData<Person>
    {
        Person FindInRepository(string email);
    }
}