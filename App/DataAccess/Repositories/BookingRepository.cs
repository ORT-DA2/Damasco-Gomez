using System;
using System.Collections.Generic;
using DataAccessInterface.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbSet<Booking> bookings;
        private readonly DbContext vidlyContext;
        public BookingRepository(DbContext context)
        {
           this.vidlyContext = context;
           this.bookings = context.Set<Booking>();
        }

        public void Add(Booking element)
        {
            this.Add(element);
        }

        public void Delete(Booking element)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistElement(Booking element)
        {
            throw new NotImplementedException();
        }

        public bool ExistElement(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistElement(Predicate<Booking> element)
        {
            throw new NotImplementedException();
        }

        public Booking Find(int id)
        {
            throw new NotImplementedException();
        }

        public Booking Find(Predicate<Booking> element)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetElements()
        {
            throw new NotImplementedException();
        }

        public void Update(Booking element)
        {
            throw new NotImplementedException();
        }

        protected void Validate(Booking element)
        {
            throw new System.NotImplementedException();
        }
    }
}