using System;
using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface IHouseLogic
    {
        IEnumerable<House> GetAll();
        House GetBy(int id);
        void Add(House category);
        void Update(House category);
        void Delete(int id);
        void Delete();
        bool Exist(House category);
    }
}