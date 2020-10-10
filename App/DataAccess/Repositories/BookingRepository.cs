using System;
using DataAccessInterface.Repositories;
using Domain;

namespace DataAccess.Repositories
{
    public class BookingRepository: AccessData<Booking> , IBookingRepository
    {
        public BookingRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Bookings;
        }

        protected override void Validate(Booking element)
        {
            if (element.HouseId > 0)
            {
                if (!element.House.IsAvailable())
                {
                    throw new ArgumentException("House is not available");
                }
            }
            else
            {
                throw new ArgumentException("You need a house to create booking");
            }
            // bool checkInAndOut = !element.CheckIn.Equals(DateTime.MinValue)
            //     && !element.CheckOut.Equals(DateTime.MinValue);
            // if (!checkInAndOut)
            // {
            //     throw new ArgumentException("There's no dates to create the booking");
            // }
        }

        protected override void Update(Booking elementToUpdate, Booking element)
        {
            elementToUpdate.Update(element);
        }

    }
}