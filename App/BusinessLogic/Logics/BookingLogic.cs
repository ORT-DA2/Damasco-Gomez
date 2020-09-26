
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic.Logics
{
    public class BookingLogic : Logic<Booking> , IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IHouseRepository houseRepository;
        public BookingLogic(IBookingRepository bookingRepository, IHouseRepository houseRepository)
        {
            this.bookingRepository = bookingRepository;
            this.houseRepository = houseRepository;
        }
        public override void Delete()
        {
            foreach(Booking Booking in this.bookingRepository.GetElements())
            {
                this.Delete(Booking.Id);
            }
        }
        public void AddHouse(int id, House house)
        {
            this.houseRepository.Add(house);
            this.bookingRepository.Find(id).House = house;
        }
    }
}