using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Collections.Generic;

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

        public IEnumerable<Region> GetAll()
        {
            return this.regions;
        }
    }
}