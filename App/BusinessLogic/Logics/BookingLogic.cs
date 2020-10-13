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
        private readonly IHouseRepository houseRepository;
        private readonly IStateRepository stateRepository;
        public BookingLogic(IBookingRepository bookingRepository, IHouseRepository houseRepository,
            IStateRepository stateRepository)
        {
            this.bookingRepository = bookingRepository;
            this.houseRepository = houseRepository;
            this.stateRepository = stateRepository;
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
            ValidateHouse(booking.HouseId);
            Booking bookingBD = this.bookingRepository.Add(booking);
            return bookingBD;
        }
        public Booking Update(int id, Booking booking)
        {
            if(booking.HouseId > 0) ValidateHouse(booking.HouseId);
            if(booking.StateId >0) ValidateState(booking.StateId);
            Booking bookingBD = this.bookingRepository.Find(id);
            bookingBD.Update(booking);
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
        public void ValidateHouse(int houseId)
        {
            if (!this.houseRepository.ExistElement(houseId))
            {
                throw new ArgumentException("There is no House with id : " + houseId);
            }
            if(!this.houseRepository.Find(houseId).IsAvailable())
            {
                throw new ArgumentException("The house is not available");
            }
        }
        public void ValidateState(int stateId)
        {
            if (!this.stateRepository.ExistElement(stateId))
            {
                throw new ArgumentException("State is not correct");
            }
        }
    }
}