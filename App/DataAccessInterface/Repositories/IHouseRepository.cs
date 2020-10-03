using System.Collections.Generic;
using Domain;
using Model;

namespace DataAccessInterface.Repositories
{
    public interface IHouseRepository : IAccessData<House>
    {
        IEnumerable<HouseSearchResultModel> GetByIdTouristPoint(int idTP);
    }
}