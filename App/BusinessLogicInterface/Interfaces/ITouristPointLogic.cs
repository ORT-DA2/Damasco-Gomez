using System;
using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;

namespace BusinessLogicInterface
{
    public interface ITouristPointLogic
    {
        IEnumerable<TouristPoint> GetAll();
        TouristPoint GetBy(int id);
        TouristPoint Add(TouristPoint element);
        void Update(int id,TouristPoint element);
        void Delete(int id);
        void Delete();
        bool Exist(TouristPoint element);
    }
}
