
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
        private readonly IHouseLogic houseLogic;
        public BookingLogic(IBookingRepository bookingRepository, IHouseLogic houseLogic)
        {
            this.bookingRepository = bookingRepository;
            this.houseLogic = houseLogic;
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
                var bookingAdded =  this.bookingRepository.Add(booking);
                if (booking.HouseId > 0)
                {
                    bookingAdded.House = this.houseLogic.GetBy(booking.HouseId);
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