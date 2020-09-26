using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class PersonLogic : Logic<Person> ,IPersonLogic
    {
        private readonly IPersonRepository personRepository;
        public PersonLogic(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public override void Delete()
        {
            foreach(Person person in this.personRepository.GetElements())
            {
                this.Delete(person.Id);
            }
        }
    }
}