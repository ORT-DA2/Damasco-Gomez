using DataAccessInterface.Repositories;
using Domain;
using System;

namespace DataAccess.Repositories
{
    public class RegionRepository : AccessData<Region> , IRegionRepository
    {
        public RegionRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Regions;
        }

        protected override void Update(Region elementToUpdate, Region element)
        {
            elementToUpdate.Update(element);
        }

        protected override void Validate(Region element)
        {
            bool nameNull = element.Name.Equals("");
            if (nameNull)
            {
                throw new ArgumentException("Name should not be empty");
            }
        }
    }
}