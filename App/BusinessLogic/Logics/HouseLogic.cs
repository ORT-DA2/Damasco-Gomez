using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class HouseLogic : IHouseLogic
    {
        private readonly IHouseRepository houseRepository;
        public HouseLogic(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository;
        }
        public IEnumerable<House> GetAll()
        {
            return this.houseRepository.GetElements();
        }
        public  House GetBy(int id)
        {
            return this.houseRepository.Find(id);
        }

        public void Add(House House)
        {
            this.houseRepository.Add(House);
        }
        public void Update(House House)
        {
            this.houseRepository.Update(House);
        }
        public void Delete(int id)
        {
            this.houseRepository.Delete(id);
        }

        public void Delete()
        {
            foreach(House House in this.houseRepository.GetElements())
            {
                this.Delete(House.Id);
            }
        }
        public bool Exist(House House)
        {
            return this.houseRepository.ExistElement(House);
        }

    }
}