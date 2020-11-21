using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Domain.Entities;

namespace BusinessLogic
{
    public class HouseLogic : IHouseLogic
    {
        private readonly ITouristPointRepository touristPointRepository;
        private readonly IHouseRepository houseRepository;
        private readonly IImageHouseRepository imageHouseRepository;
        public HouseLogic(IHouseRepository houseRepository, 
            ITouristPointRepository touristPointRepository,
            IImageHouseRepository imageHouseRepository)
        {
            this.houseRepository = houseRepository;
            this.touristPointRepository = touristPointRepository;
            this.imageHouseRepository = imageHouseRepository;
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
            ValidateTouristPoint(house.TouristPointId);
            house.CreatedOn = DateTime.Now;
            House houseAdded = this.houseRepository.Add(house);
            return houseAdded;
        }
        public House Update(int id, House house)
        {
            if(house.TouristPointId > 0) 
            {
                ValidateTouristPoint(house.TouristPointId);
            }
            House houseBD = this.houseRepository.Find(id);
            if(house.ImagesHouse.Count > 0) 
            {
                houseBD.ImagesHouse.ForEach
                (
                    m => m = this.imageHouseRepository.Find(m.Id)
                );
                houseBD.ImagesHouse.RemoveAll(x => x.Id == houseBD.Id);
                houseBD.ImagesHouse = house.ImagesHouse;
            }
            houseBD.Update(house);
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
        public void ValidateTouristPoint(int touristPointId)
        {
            if (!this.touristPointRepository.ExistElement(touristPointId))
            {
                throw new ArgumentException("There is no Tourist point with id  " + touristPointId);
            }
        }
    }
}
