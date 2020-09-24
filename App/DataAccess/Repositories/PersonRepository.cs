using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PersonRepository : AccessData<Person> , IPersonRepository
    {
        private readonly DbSet<Person> persons;
        private readonly DbContext vidlyContext;
        public PersonRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.persons = context.Set<Person>();
        }
    }
}