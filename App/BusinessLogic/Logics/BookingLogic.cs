
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic.Logics
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IHouseRepository houseRepository;
        public BookingLogic(IBookingRepository bookingRepository, IHouseRepository houseRepository)
        {
            this.bookingRepository = bookingRepository;
            this.houseRepository = houseRepository;
        }
        public void Delete()
        {
            foreach(Booking Booking in this.bookingRepository.GetElements())
            {
                this.Delete(Booking.Id);
            }
        }
        public IEnumerable<Booking> GetAll()
        {
            return this.bookingRepository.GetElements();
        }
        public  Booking GetBy(int id)
        {
            return this.bookingRepository.Find(id);
        }

        public Booking Add(Booking Booking)
        {
            return this.bookingRepository.Add(Booking);
        }
        public void Update(Booking Booking)
        {
            this.bookingRepository.Update(Booking);
        }
        public void Delete(int id)
        {
            this.bookingRepository.Delete(id);
        }
        public bool Exist(Booking Booking)
        {
            return this.bookingRepository.ExistElement(Booking);
        }
    }
}