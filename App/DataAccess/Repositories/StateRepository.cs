using System;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class StateRepository : AccessData<State> , IStateRepository
    {
        public StateRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.States;
        }

        protected override void Update(State elementToUpdate, State element)
        {
        }

        protected override void Validate(State element)
        {
        }
    }
}