using System;
using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class HouseLogic : Logic<House> , IHouseLogic
    {
        private readonly IHouseRepository houseRepository;
        public HouseLogic(IHouseRepository houseRepository)
        {
            this.houseRepository = houseRepository;
        }

        public override void Delete()
        {
            foreach(House House in this.houseRepository.GetElements())
            {
                this.Delete(House.Id);
            }
        }

    }
}