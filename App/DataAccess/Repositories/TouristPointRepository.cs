using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class TouristPointRepository : AccessData<TouristPoint> , ITouristPointRepository
    {
       public TouristPointRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.TouristPoints;
       }

        protected override void Validate(TouristPoint element)
        {
            //throw new NotImplementedException();
        }
    }
}