using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogicInterface.Interfaces
{
    public interface IStateLogic
    {
        IEnumerable<State> GetAll();
        State GetBy(int stateId);
    }
}