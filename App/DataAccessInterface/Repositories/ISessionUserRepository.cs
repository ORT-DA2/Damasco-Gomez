using System;
using Domain.Entities;

namespace DataAccessInterface.Repositories
{
    public interface ISessionUserRepository  : IAccessData<SessionUser>
    {
        bool IsCorrectToken(Guid token);
    }

}