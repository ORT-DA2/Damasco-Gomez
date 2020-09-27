using System;
using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;

namespace BusinessLogicInterface
{
    public interface IHouseLogic
    {
        IEnumerable<House> GetAll();
        House GetBy(int id);
        void Add(House element);
        void Update(House element);
        void Delete(int id);
        void Delete();
        bool Exist(House element);
    }
}