using System;

namespace DataAccessInterface.Repositories
{
    public interface ISessionUserRepository
    {
        bool IsCorrectToken(Guid token);
    }

}