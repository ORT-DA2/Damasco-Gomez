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
            return this.stateRepository.GetElements();
        }

        public State GetBy(int stateId)
        {
            return this.stateRepository.Find(stateId);
        }
    }
}