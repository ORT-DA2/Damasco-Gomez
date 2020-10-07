
using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Model;

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
            foreach(Booking booking in this.bookingRepository.GetElements())
            {
                this.Delete(booking.Id);
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

        public Booking Add(Booking booking)
        {
            Validate(booking);
            Booking bookingBD = this.bookingRepository.Add(booking);
            //bookingBD.House = this.houseRepository.Find(booking.HouseId);
            return bookingBD;
        }
        public Booking Update(int id, Booking booking)
        {
            Validate(booking);
            Booking bookingBD = this.bookingRepository.Find(id);
            bookingBD.Update(booking);
            //bookingBD.House = this.houseRepository.Find(booking.HouseId);
            this.bookingRepository.Update(id, bookingBD);
            return bookingBD;
        }
        public void Delete(int id)
        {
            this.bookingRepository.Delete(id);
        }
        public bool Exist(Booking booking)
        {
            return this.bookingRepository.ExistElement(booking);
        }
        public void Validate(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentException("Booking is empty");
            }
            if (!this.houseRepository.ExistElement(booking.HouseId))
            {
                throw new ArgumentException("There is no House with id : " + booking.HouseId);
            }
        }
    }
}