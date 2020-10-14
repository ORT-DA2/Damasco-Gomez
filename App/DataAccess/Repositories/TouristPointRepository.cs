using System;
using System.Diagnostics.CodeAnalysis;
using DataAccessInterface.Repositories;
using Domain;
namespace DataAccess.Repositories
{
    public class TouristPointRepository : AccessData<TouristPoint> , ITouristPointRepository
    {
        public TouristPointRepository(RepositoryMaster repositoryMaster)
        {
                this.repository = repositoryMaster.TouristPoints;
        }
        [ExcludeFromCodeCoverage]
        protected override void Update(TouristPoint elementToUpdate, TouristPoint element)
        {
            elementToUpdate.Update(element);
        }

        protected override void Validate(TouristPoint element)
        {
            bool regionIdNull = element.RegionId == 0;
            if (regionIdNull)
            {
                throw new ArgumentException("The tourist point need a region");
            }
        }
    }
}