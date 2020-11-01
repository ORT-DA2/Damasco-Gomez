using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class StateLogic : IStateLogic
    {
        public IEnumerable<State> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<State> GetBy(int stateId)
        {
            throw new System.NotImplementedException();
        }
    }
}