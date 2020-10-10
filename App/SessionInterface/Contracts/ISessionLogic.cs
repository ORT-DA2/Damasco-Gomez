using System;

namespace Contracts
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(Guid token);

        void Login(string userName , string password) ;
    }
}
