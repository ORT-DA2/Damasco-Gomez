using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface.Interfaces
{
    public interface IStateLogic
    {
        IEnumerable<State> GetAll();
        IEnumerable<State> GetBy(int stateId);
    }
}