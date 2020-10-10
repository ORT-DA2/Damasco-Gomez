using System;
using Contracts;
using DataAccessInterface.Repositories;

namespace BusinessLogic.Logics
{
    public class SessionLogic : ISessionLogic
    {
        private readonly ISessionUserRepository sessionUserRepository;
       public SessionLogic(ISessionUserRepository sessionUserRepository)
       {
           this.sessionUserRepository = sessionUserRepository;
       }

        public bool IsCorrectToken(Guid token)
        {
             return this.sessionUserRepository.IsCorrectToken(token);

        }
    }
}