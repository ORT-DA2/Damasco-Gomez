using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class SessionLogic : ISessionLogic
    {
        private readonly ISessionUserRepository sessionUserRepository;

        private readonly IPersonRepository personRepository;
       public SessionLogic(ISessionUserRepository sessionUserRepository, IPersonRepository personRepository)
       {
           this.sessionUserRepository = sessionUserRepository;
           this.personRepository = personRepository;
       }

        public bool IsCorrectToken(Guid token)
        {
             return this.sessionUserRepository.IsCorrectToken(token);

        }
        public void Login(Person person)  
        {
            List<Person> personResult = this.personRepository.GetElements().FindAll((p=>p.Email == person.Email && p.Password == person.Password));
            if (personResult.Count==0)
            {
                throw new ArgumentException("Email or password was not valid ");
            
            person = personResult.First();
            Guid guid = Guid.NewGuid();
            List <SessionUser> sessions = this.sessionUserRepository.GetElements().FindAll(m=>m.PersonId==person.Id);
            if(sessions.Count==0)
            {
                SessionUser newSession = new SessionUser ()
                {
                    Token = guid,
                    PersonId = person.Id
                };
                this.sessionUserRepository.Add(newSession);
            }
            else
            {
                sessions.First().Update(guid);
            }
        }
    }
}