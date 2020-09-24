using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BookingRepository : AccessData<Booking> , IBookingRepository
    {
        private readonly DbSet<Booking> bookings;
       private readonly DbContext vidlyContext;
       public BookingRepository(DbContext context)
       {
           this.vidlyContext = context;
           this.bookings = context.Set<Booking>();
       }
    }
}