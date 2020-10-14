using System.Collections.Generic;
using Domain;
using Domain.Entities;

namespace BusinessLogicInterface
{
    public interface IHouseLogic
    {
        IEnumerable<House> GetAll();
        House GetBy(int id);
        House Add(House element);
        House Update(int id,House element);
        void Delete(int id);
        void Delete();
        bool Exist(House element);
        IEnumerable<House> GetHousesBy(HouseSearch houseSearch);
    }
}
