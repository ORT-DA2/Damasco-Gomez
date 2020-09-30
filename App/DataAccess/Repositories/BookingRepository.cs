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
            bool houseAvailable = false;
            if (element.House != null)
            {
                houseAvailable = element.House.Avaible;
            }
            if (!houseAvailable)
            {
                throw new ArgumentException("House is not available");
            }
            bool checkInAndOut = !element.CheckIn.Equals(DateTime.MinValue)
                && !element.CheckOut.Equals(DateTime.MinValue);
            if (!checkInAndOut)
            {
                throw new ArgumentException("There's no dates to create the booking");
            }
        }
    }
}