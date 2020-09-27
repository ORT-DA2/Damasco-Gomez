using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PersonRepository : AccessData<Person> , IPersonRepository
    {
        public PersonRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Persons;
        }

        protected override void Validate(Person element)
        {
            //throw new System.NotImplementedException();
        }
    }
}