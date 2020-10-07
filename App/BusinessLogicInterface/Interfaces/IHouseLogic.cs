using System;
using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;
using Domain.Entities;
using Model;

namespace BusinessLogicInterface
{
    public interface IHouseLogic
    {
        IEnumerable<House> GetAll();
        House GetBy(int id);
        House Add(House element);
        void Update(int id,House element);
        void Delete(int id);
        void Delete();
        bool Exist(House element);
        IEnumerable<House> GetHousesBy(HouseSearch houseSearch);
    }
}
