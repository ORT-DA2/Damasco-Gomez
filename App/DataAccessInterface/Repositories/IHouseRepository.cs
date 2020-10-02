using System.Collections.Generic;
using Domain;

namespace DataAccessInterface.Repositories
{
    public interface IHouseRepository : IAccessData<House>
    {
        IEnumerable<House> GetByIdTouristPoint(int idTP);
    }
}