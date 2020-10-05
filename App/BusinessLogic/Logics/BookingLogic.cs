
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
            if (booking != null)
            {
                if (booking.HouseId > 0)
                {
                    House house = this.houseRepository.Find(booking.HouseId);
                    booking.House = house ;
                    booking =  this.bookingRepository.Add(booking);
                }
                return booking;
            }
            throw new ArgumentException("The booking is empty");
        }
        public void Update(int id, Booking booking)
        {
            this.bookingRepository.Update(id, booking);
        }
        public void Delete(int id)
        {
            this.bookingRepository.Delete(id);
        }
        public bool Exist(Booking booking)
        {
            return this.bookingRepository.ExistElement(booking);
        }
    }
}