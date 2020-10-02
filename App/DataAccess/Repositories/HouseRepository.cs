using System;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

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
            throw new NotImplementedException();
        }

        protected override void Validate(House element)
        {
            bool pricePerNight = element.PricePerNight <= 0;
            if (pricePerNight)
            {
                throw new ArgumentException("Price per night should be bigger than 0");
            }
            bool starts = element.Starts < 1 || element.Starts > 5  ;
            if (starts)
            {
                throw new ArgumentException("Starts number is between 1 and 5");
            }
            // bool touristPointNotNull = !element.Spot.Equals(null);
            // bool nameNotNull = element.Name.Equals("");
            // bool addressNotNull = !element.Equals("");
        }
    }
}