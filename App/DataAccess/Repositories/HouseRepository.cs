using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class HouseRepository : AccessData<House> , IHouseRepository
    {
        public HouseRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Houses;
        }

        protected override void Validate(House element)
        {
            throw new System.NotImplementedException();
        }
    }
}