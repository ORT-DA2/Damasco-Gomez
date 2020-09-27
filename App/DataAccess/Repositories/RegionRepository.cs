using DataAccessInterface.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class RegionRepository : AccessData<Region> , IRegionRepository
    {
        public RegionRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Regions;
        }

        protected override void Validate(Region element)
        {
            //throw new System.NotImplementedException();
        }
    }
}