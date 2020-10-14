using System;
using System.Diagnostics.CodeAnalysis;
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
            bool priceZero = element.Price == 0;
            if (priceZero)
            {
                throw new ArgumentException("Price should not be zero");
            }
            bool nameNull = element.Name==null;
            if (nameNull)
            {
                throw new ArgumentException("Can't create a Booking without name");
            }
            bool checkInAndOut = !element.CheckIn.Equals(DateTime.MinValue)
                && !element.CheckOut.Equals(DateTime.MinValue);
            if (!checkInAndOut)
            {
                throw new ArgumentException("There's no dates to create the booking");
            }
        }
        [ExcludeFromCodeCoverage]
        protected override void Update(Booking elementToUpdate, Booking element)
        {
            elementToUpdate.Update(element);
        }

    }
}