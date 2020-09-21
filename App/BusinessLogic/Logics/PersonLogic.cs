using BusinessLogicInterface;
using DataAccessInterface.Repositories;

namespace BusinessLogic
{
    public class PersonLogic : IPersonLogic
    {
        private readonly IPersonRepository personRepository;
        public PersonLogic(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        // public void CreateUser(string token)
        // {
            
        // }
        // public void SetPassword(int id, string token)
        // {
            
        // }
        // public void UpdateEmail(int id, string email, string token)
        // {
            
        // }
        // public void UpdatePassword(int id, string password, string token)
        // {
            
        // }
        // public void UpdateName(int id, string name, string token)
        // {
            
        // }
    }
}