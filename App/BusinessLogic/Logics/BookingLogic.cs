
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic.Logics
{
    public class BookingLogic : Logic<Booking> , IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;
        public BookingLogic(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public override void Delete()
        {
            foreach(Booking Booking in this.bookingRepository.GetElements())
            {
                this.Delete(Booking.Id);
            }
        }
    }
}