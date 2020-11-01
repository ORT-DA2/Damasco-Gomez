using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using DataAccessInterface.Repositories;
using Domain.Entities;

namespace BusinessLogic.Logics
{
    public class StateLogic : IStateLogic
    {
        private readonly IStateRepository stateRepository;
        public StateLogic(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        } 
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