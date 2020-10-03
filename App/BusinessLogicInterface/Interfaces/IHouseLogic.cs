using System;
using System.Collections.Generic;
using BusinessLogicInterface.Interfaces;
using Domain;
using Model;

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
        IEnumerable<HouseSearchResultModel> GetHousesBy(int idTP,string checkIn, string checkOut, int cantA,int cantC,int cantB);
        double  CalcualateTotalPrice(int CantA, int CantC, int CantB ,House house)
    }
}