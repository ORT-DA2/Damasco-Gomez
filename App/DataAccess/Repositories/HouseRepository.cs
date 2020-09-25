using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class HouseRepository : AccessData<House> , IHouseRepository
    {
        private readonly DbSet<House> houses;
        private readonly DbContext vidlyContext;
        public HouseRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.houses = context.Set<House>();
        }

        protected override void Validate(House element)
        {
            throw new System.NotImplementedException();
        }
    }
}