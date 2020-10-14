using System;
using DataAccessInterface.Repositories;
using Domain;

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
            Person emailUniq = this.FindInRepository(element.Email);
            if (emailUniq!=null)
            {
                throw new ArgumentException("The email is already in the database");
            }
        }

        public Person FindInRepository(string email)
        {
            Person findByEmail = null;
            foreach(var p in this.repository.GetElementsInContext())
            {
                if (p.Email == email)
                {
                   findByEmail = p;
                }
            }
            return findByEmail;
        }

        protected override void Update(Person elementToUpdate, Person element)
        {
            elementToUpdate.Update(element);
        }
    }
}