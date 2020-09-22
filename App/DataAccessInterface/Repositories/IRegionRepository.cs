using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DataAccessInterface.Repositories
{
    public interface IRegionRepository
    {
         IEnumerable <Region> GetAll();
    }
}