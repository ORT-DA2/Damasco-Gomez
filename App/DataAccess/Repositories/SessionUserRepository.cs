using System;
using DataAccessInterface.Repositories;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class SessionUserRepository : AccessData<SessionUser>, ISessionUserRepository
    {
        public SessionUserRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Sessions;
       }
        protected override void Update(SessionUser elementToUpdate, SessionUser element)
        {
            throw new System.NotImplementedException();
        }

        protected override void Validate(SessionUser element)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCorrectToken(Guid token)
        {
            var result = this.repository.GetElementsInContext();
            var resultToReturn = result.FindAll(kz=>kz.Token==token);
            if (resultToReturn.Count==0)
            {
                throw new ArgumentException("No user with that id ");
            }
            return true;
        }
    }
}