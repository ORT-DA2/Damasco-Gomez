using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly DbSet<House> houses;
        private readonly DbContext vidlyContext;
        public HouseRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.houses = context.Set<House>();
        }        
    }
}