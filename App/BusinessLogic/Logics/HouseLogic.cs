using System;
using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;
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
        public IEnumerable<House>  GetHousesBy(HouseSearch houseSearch)
        {
            return this.houseRepository.GetByIdTouristPoint(houseSearch.TouristPointId);
        }
    }
}
