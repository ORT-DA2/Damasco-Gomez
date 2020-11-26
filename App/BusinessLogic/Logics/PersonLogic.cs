using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IPersonRepository personRepository;
        public PersonLogic(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public void Delete()
        {
            foreach(Person Person in this.personRepository.GetElements())
            {
                this.Delete(Person.Id);
            }
        }
        public IEnumerable<Person> GetAll()
        {
            return this.personRepository.GetElements();
        }
        public Person GetBy(int id)
        {
            return this.personRepository.Find(id);
        }

        public Person Add(Person person)
        {
            return this.personRepository.Add(person);
        }
        public Person Update(int id, Person person)
        {
            Person personBd = this.personRepository.Find(id);
            personBd.Update(person);
            this.personRepository.Update(id,personBd);
            return personBd;
        }
        public void Delete(int id)
        {
            this.personRepository.Delete(id);
        }
        public bool Exist(Person Person)
        {
            return this.personRepository.ExistElement(Person);
        }
    }
}