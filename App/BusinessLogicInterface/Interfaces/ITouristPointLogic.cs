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
        void Add(TouristPoint element);
        void Update(TouristPoint element);
        void Delete(int id);
        void Delete();
        bool Exist(TouristPoint element);
    }
}
