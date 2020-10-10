using System;
using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface ITouristPointLogic
    {
        IEnumerable<TouristPoint> GetAll();
        TouristPoint GetBy(int id);
        TouristPoint Add(TouristPoint element);
        TouristPoint Update(int id,TouristPoint element);
        void Delete(int id);
        void Delete();
        bool Exist(TouristPoint element);
    }
}
