
using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic.Logics
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingRepository bookingRepository;
        public BookingLogic(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
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
            try
            {
                return this.bookingRepository.Find(id);
            }
            catch(ArgumentException)
            {
                throw new ArgumentException("No booking with that id");
            }
        }

        public Booking Add(Booking Booking)
        {
            return this.bookingRepository.Add(Booking);
        }
        public void Update(int id, Booking Booking)
        {
            this.bookingRepository.Update(id, Booking);
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