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
        public Guid Login(Person person)
        {
            IEnumerable<Person> personResult = this.personRepository.GetElements().Where(p => p.Email == person.Email && p.Password == person.Password);
            if (personResult.Count() == 0)
            {
                throw new ArgumentException("Email or password was not valid ");
            }
            person = personResult.First();
            Guid guid = Guid.NewGuid();
            IEnumerable<SessionUser> sessions = this.sessionUserRepository.GetElements().Where(m => m.PersonId == person.Id);
            if (sessions.Count() == 0)
            {
                SessionUser newSession = new SessionUser()
                {
                    Token = guid,
                    PersonId = person.Id
                };
                this.sessionUserRepository.Add(newSession);
            }
            else
            {
                SessionUser session = this.sessionUserRepository.Find(sessions.First().Id);
                session.Token = guid;
                this.sessionUserRepository.Update(session.Id, session);
            }
            return guid;
        }
    }
}