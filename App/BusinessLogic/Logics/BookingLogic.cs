
using BusinessLogicInterface;
using DataAccessInterface.Repositories;

namespace BusinessLogic.Logics
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;
        public BookingLogic(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        // void GetBookingById(int id)
        // {

        // }

        // void GetBookingByName(string name)
        // {

        // }

        // void CreateBooking(int checkIn, int checkOut, string name, string email, string house, string token)        
        // {
        // }

        // void GetCode(int id, string token)
        // {

        // }

        // void DeleteBooking(int id, string token)
        // {

        // }

    }
}