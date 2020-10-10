using System;
using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess.Repositories
{
    public class HouseRepository : AccessData<House> , IHouseRepository
    {
        public HouseRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Houses;
        }

        protected override void Update(House elementToUpdate, House element)
        {
            elementToUpdate.Update(element);
        }

        protected override void Validate(House element)
        {
            bool pricePerNight = element.PricePerNight <= 0;
            if (pricePerNight)
            {
                throw new ArgumentException("Price per night should be bigger than 0");
            }
            bool startsCorrect = element.Starts > 0 && element.Starts < 6  ;
            if (!startsCorrect)
            {
                throw new ArgumentException("Starts number is between 1 and 5");
            }
        }
        public IEnumerable<House> GetByIdTouristPoint(int idTP)
        {
            var result = this.repository.GetElementsInContext();
            var resultToReturn = result.FindAll(kz=>kz.TouristPointId==idTP && kz.Avaible);
            return resultToReturn;
        }
    }
}

