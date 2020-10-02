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
        House Add(House element);
        void Update(House element);
        void Delete(int id);
        void Delete();
        bool Exist(House element);
        IEnumerable<House> GetHousesBy(int idTP,string checkIn,string checkOut,int cantA,int cantC,int cantB);
    }
}