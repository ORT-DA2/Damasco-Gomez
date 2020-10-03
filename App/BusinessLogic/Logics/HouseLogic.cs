using System;
using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Model;

namespace BusinessLogic
{
    public class HouseLogic : IHouseLogic
    {
       
        private readonly IHouseRepository houseRepository;
        public HouseLogic(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository;
        }

        public void Delete()
        {
            foreach(House House in this.houseRepository.GetElements())
            {
                this.Delete(House.Id);
            }
        }
        public IEnumerable<House> GetAll()
        {
            return this.houseRepository.GetElements();
        }
        public House GetBy(int id)
        {
            return this.houseRepository.Find(id);
        }

        public House Add(House House)
        {
            return this.houseRepository.Add(House);
        }
        public void Update(int id, House House)
        {
            this.houseRepository.Update(id, House);
        }
        public void Delete(int id)
        {
            this.houseRepository.Delete(id);
        }
        public bool Exist(House House)
        {
            return this.houseRepository.ExistElement(House);
        }
        public IEnumerable<House>  GetHousesBy(int idTP,string checkIn, string checkOut, int cantA,int cantC,int cantB)
        {
            return this.houseRepository.GetByIdTouristPoint(idTP);
        }
        public double  GenerateModel(int CantA, int CantC, int CantB ,House house)
        {
            int TotalPrice = this.NEWlogic.PricePer()
            Model houseModel = new Model(House);
            houseModel.TotalPrice = TotalPrice;
            return TotalPrice;

        }
        public int TotalPrice()
        {
            int pricePerNight =house.PricePerNight;
            int  PriceAdults = CantA* pricePerNight;
            const double percentChildrens = 0.5;
            const double percentBabys = 0.5;
            double  PriceChildrens = CantB* percentChildrens * pricePerNight;
            double  PriceBabys = CantB* percentBabys * pricePerNight;
            double TotalPrice= PriceAdults + PriceChildrens + PriceBabys;
            return TotalPrice ;
        }
    }
}
