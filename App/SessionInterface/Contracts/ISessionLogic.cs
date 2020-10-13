using System;
using Domain;

namespace Contracts
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(Guid token);

        Guid Login(Person person) ;
    }
}
