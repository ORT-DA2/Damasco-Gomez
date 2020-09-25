using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BookingRepository : AccessData<Booking> , IBookingRepository
    {
        public BookingRepository(RepositoryMaster repositoryMaster)
        {
            this.repository = repositoryMaster.Bookings;

            // this.vidlyContext = context;
            // this.bookings = context.Set<Booking>();
        }

        protected override void Validate(Booking element)
        {
            throw new System.NotImplementedException();
        }
    }
}