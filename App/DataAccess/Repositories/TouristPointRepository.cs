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
       private readonly DbSet<TouristPoint> touristPoints;
       private readonly DbContext vidlyContext;
       public TouristPointRepository(DbContext context)
       {
           this.vidlyContext = context;
           this.touristPoints = context.Set<TouristPoint>();
       }

        protected override void Validate(TouristPoint element)
        {
            throw new NotImplementedException();
        }
    }
}