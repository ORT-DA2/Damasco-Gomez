using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DbSet<Region> regions;
        private readonly DbContext vidlyContext;
        public RegionRepository(DbContext context)
        {
            this.vidlyContext = context;
            this.regions = context.Set<Region>();
        }
    }
}