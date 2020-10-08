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
        private readonly ITouristPointRepository touristPointRepository;
        private readonly IHouseRepository houseRepository;
        public HouseLogic(IHouseRepository houseRepository, ITouristPointRepository touristPointRepository)
        {
            this.houseRepository = houseRepository;
            this.touristPointRepository = touristPointRepository;
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

        public House Add(House house)
        {
            Validate(house);
            House houseAdded = this.houseRepository.Add(house);
            return houseAdded;
        }
        public House Update(int id, House house)
        {
            Validate(house);
            House houseBD = this.houseRepository.Find(id);
            houseBD.Update(house);
            //houseBD.House = this.houseRepository.Find(house.HouseId);
            this.houseRepository.Update(id, houseBD);
            return houseBD;
        }
        public void Delete(int id)
        {
            this.houseRepository.Delete(id);
        }
        public bool Exist(House house)
        {
            return this.houseRepository.ExistElement(house);
        }
        public IEnumerable<House> GetHousesBy(HouseSearch houseSearch)
        {
            return this.houseRepository.GetByIdTouristPoint(houseSearch.TouristPointId);
        }
        public void Validate(House house)
        {
            if (house == null)
            {
                throw new ArgumentException("House is empty");
            }
            if (!this.touristPointRepository.ExistElement(house.TouristPointId))
            {
                throw new ArgumentException("There is no Tourist point with id  " + house.TouristPointId);
            }
        }
    }
}
