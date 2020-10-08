using System;

namespace Contracts
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(string token);
    }
}
