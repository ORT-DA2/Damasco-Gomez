using System;
using Domain;

namespace Contracts
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(Guid token);

        void Login(Person person) ;
    }
}
